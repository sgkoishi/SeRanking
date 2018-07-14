using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using Wolfje.Plugins.SEconomy;

namespace Chireiden.SEconomy.Ranking
{
    [ApiVersion(2, 1)]
    public class Ranking : TerrariaPlugin
    {
        private Config config;

        public Ranking(Main game) : base(game)
        {
        }

        public override string Author => "SGKoishi";

        public override string Name => "Ranking";

        public override Version Version => new Version(1, 0, 0, 0);

        public override void Initialize()
        {
            ReadConfig("tshock\\ranking.json", Lang.DefaultConfig(false), out config);
            var ir = 0;
            foreach (var level in config.Levels)
            {
                Levels[level.TsGroup] = level;
                foreach (var i in level.AllowedItems)
                {
                    var itembanName = Terraria.Lang.GetItemNameValue(i);
                    if (!TShock.Itembans.ItemIsBanned(itembanName))
                    {
                        ir++;
                        TShock.Itembans.AddNewBan(itembanName);
                    }
                }
            }

            Console.WriteLine(config.Messages["Load"], Levels.Count, ir);

            Commands.ChatCommands.Add(new Command(config.ViewLevelPermission, ViewLevel,
                !config.ViewLevelCommand.Contains(" ")
                    ? config.ViewLevelCommand
                    : throw new ArgumentException("Command contains space")));
            Commands.ChatCommands.Add(new Command(config.RankPermission, LevelUp, !config.LevelUpCommand.Contains(" ")
                ? config.LevelUpCommand
                : throw new ArgumentException("Command contains space")));
            Commands.ChatCommands.Add(new Command(config.RankPermission, ClassSelect,
                !config.ClassSelectCommand.Contains(" ")
                    ? config.ClassSelectCommand
                    : throw new ArgumentException("Command contains space")));
        }

        private static readonly Dictionary<string, Level> Levels = new Dictionary<string, Level>();

        private void ViewLevel(CommandArgs args)
        {
            Rank(args.Player, args.Parameters, false);
        }

        private void LevelUp(CommandArgs args)
        {
            Rank(args.Player, args.Parameters, true);
        }

        private void ClassSelect(CommandArgs args)
        {
            Rank(args.Player, args.Parameters, true);
        }

        private void Rank(TSPlayer p, List<string> args, bool tryLevel)
        {
            if (p.HasPermission(config.RankExcludePermission))
            {
                p.SendInfoMessage(config.Messages["RankExclude"]);
            }

            LazyLoad(p);
            var nextLevel = GetChildren(p.Group.Name);
            switch (nextLevel.Count())
            {
                case 0:
                {
                    if (GetLevel(p.Group.Name) != null)
                    {
                        p.SendInfoMessage(config.Messages["MaxLevel"]);
                        return;
                    }

                    var nl = config.Levels.Single(l => l.Parents.Count == 0);
                    p.SendInfoMessage(tryLevel
                        ? Move(p, nl, GetLevel(p.Group.Name))
                            ? config.Messages["RankStart"]
                            : config.Messages["RankFail"]
                        : config.Messages["NotInRank"]);
                    break;
                }
                case 1:
                {
                    if (tryLevel)
                    {
                        if (!Move(p, nextLevel.First(), GetLevel(p.Group.Name)))
                        {
                            p.SendInfoMessage(config.Messages["RankFail"]);
                        }
                    }
                    else
                    {
                        p.SendInfoMessage(InfoPlayer(p, nextLevel.First(), GetLevel(p.Group.Name),
                            config.Messages["ViewLevel"]));
                    }

                    break;
                }
                default:
                {
                    if (args.Count > 0)
                    {
                        var selected = nextLevel.Where(l => l.DisplayName == args[0]);
                        if (!selected.Any())
                        {
                            p.SendInfoMessage(config.Messages["NoMatchClass"]);
                        }

                        else if (selected.Count() > 1)
                        {
                            p.SendInfoMessage(config.Messages["MultiMatchClass"]);
                        }
                        else
                        {
                            if (!Move(p, selected.First(), GetLevel(p.Group.Name)))
                            {
                                p.SendInfoMessage(config.Messages["RankFail"]);
                            }
                        }
                    }
                    else
                    {
                        var currentClass = p.Group.Name.Split('_')[0];
                        p.SendInfoMessage(InfoPlayer(p, null, GetLevel(p.Group.Name),
                            config.Messages["ViewLevel"]));
                        p.SendInfoMessage(string.Join("\r\n", nextLevel.Select(l =>
                            string.Format(config.Messages["ClassFormat"], l.DisplayName,
                                l.Description, l.Parents[currentClass]))));
                    }

                    break;
                }
            }
        }

        private Level GetLevel(string groupName)
        {
            if (Levels.ContainsKey(groupName.Split('_')[0]))
            {
                return Levels[groupName.Split('_')[0]];
            }

            return null;
        }

        private IEnumerable<Level> GetChildren(string groupName)
        {
            var currentClass = groupName.Split('_')[0];
            var ret = new List<Level>();
            foreach (var kvp in Levels)
            {
                if (kvp.Value.Parents.Keys.Contains(currentClass))
                {
                    ret.Add(kvp.Value);
                }
            }

            return ret;
        }

        private void LazyLoad(TSPlayer tsPlayer)
        {
            var children = GetChildren(tsPlayer.Group.Name);
            foreach (var level in children)
            {
                var currentGroupName = tsPlayer.Group.Name.Split('_');
                if (level.Parents.Count == 1)
                {
                    currentGroupName[0] = level.TsGroup;
                }
                else
                {
                    currentGroupName[0] = level.TsGroup + "_" + currentGroupName[0];
                }

                var nextLevel = string.Join("_", currentGroupName);
                if (TShock.Groups.GroupExists(nextLevel))
                {
                    break;
                }

                TShock.Groups.AddGroup(nextLevel, tsPlayer.Group.Name, "", level.ChatColor);
                foreach (var valueAllowedItem in level.AllowedItems)
                {
                    var itembanName = Terraria.Lang.GetItemNameValue(valueAllowedItem);
                    if (!TShock.Itembans.ItemIsBanned(itembanName))
                    {
                        TShock.Itembans.AddNewBan(itembanName);
                    }

                    TShock.Itembans.AllowGroup(itembanName, nextLevel);
                }
            }
        }

        internal static string Color2String(Color c)
        {
            return $"{c.R:D3},{c.G:D3},{c.B:D3}";
        }

        private bool Move(TSPlayer p, Level newLevel, Level oldLevel)
        {
            var playerAccount = SEconomyPlugin.Instance.GetBankAccount(p);
            if (playerAccount == null || playerAccount.IsAccountEnabled == false ||
                !Money.TryParse(newLevel.Parents[oldLevel.TsGroup], out var commandCost))
            {
                return false;
            }

            if (playerAccount.Balance < commandCost)
            {
                p.SendErrorMessage(config.Messages["MoreXpRequired"]);
                return false;
            }

            playerAccount.Balance -= commandCost;
            var currentGroupName = p.Group.Name.Split('_');
            if (newLevel.Parents.Count == 1)
            {
                currentGroupName[0] = newLevel.TsGroup;
            }
            else
            {
                currentGroupName[0] = newLevel.TsGroup + "_" + currentGroupName[0];
            }

            var nextLevel = string.Join("_", currentGroupName);
            p.Group = TShock.Groups.GetGroupByName(nextLevel);
            newLevel.LevelUpCommand.ForEach(f => PLI(TSPlayer.Server, f));
            newLevel.LevelUpInvoke.ForEach(f => PLI(p, f));
            return true;
        }

        private static string InfoPlayer(TSPlayer p, Level nl, Level ol, string s)
        {
            var playerAccount = SEconomyPlugin.Instance.GetBankAccount(p);
            if (playerAccount == null || playerAccount.IsAccountEnabled == false)
            {
                return string.Format(s, ol.DisplayName, nl?.DisplayName ?? "", "");
            }

            return string.Format(s, ol.DisplayName, nl?.DisplayName ?? "", playerAccount.Balance);
        }

        private static void ReadConfig<TConfig>(string path, TConfig defaultConfig, out TConfig config)
        {
            if (!File.Exists(path))
            {
                config = defaultConfig;
                File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            else
            {
                config = JsonConvert.DeserializeObject<TConfig>(File.ReadAllText(path));
                File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }

        public static void PLI(TSPlayer player, string text, bool silent = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var args = (List<string>) typeof(Commands)
                .GetMethod("ParseParameters", BindingFlags.NonPublic | BindingFlags.Static)
                ?.Invoke(null, new object[] {text.Remove(0, 1)});

            if (args == null || args.Count < 1)
            {
                return;
            }

            var cmdName = args[0].ToLower();
            args.RemoveAt(0);
            var cmds = Commands.ChatCommands.Where(c => c.HasAlias(cmdName));

            if (!cmds.Any())
            {
                if (player.AwaitingResponse.ContainsKey(cmdName))
                {
                    Action<CommandArgs> call = player.AwaitingResponse[cmdName];
                    player.AwaitingResponse.Remove(cmdName);
                    call(new CommandArgs(text.Remove(0, 1), player, args));
                    return;
                }

                player.SendErrorMessage("Invalid command entered. Type /help for a list of valid commands.");
                return;
            }

            foreach (var cmd in cmds)
            {
                if (!cmd.AllowServer && !player.RealPlayer)
                {
                    player.SendErrorMessage("You must use this command in-game.");
                }
                else
                {
                    if (cmd.DoLog && silent == false)
                        TShock.Utils.SendLogs($"{player.Name} executed: /{text.Remove(0, 1)}.", Color.Red);
                    try
                    {
                        var cmdDelegateRef = cmd.CommandDelegate;

                        cmdDelegateRef(new CommandArgs(text.Remove(0, 1), false, player, args));
                    }
                    catch (Exception e)
                    {
                        player.SendErrorMessage("Command failed, check logs for more details.");
                        TShock.Log.Error(e.ToString());
                    }
                }
            }
        }
    }
}