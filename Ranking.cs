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
using Wolfje.Plugins.SEconomy.Journal;

namespace Chireiden.SEconomy.Ranking
{
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
            ReadConfig("tshock\\ranking.json", Lang.DefaultConfig(), out config);
            foreach (var level in config.Levels)
            {
                Levels[level.TsGroup] = level;
            }

            Commands.ChatCommands.Add(new Command(config.ViewLevelPermission, ViewLevel,
                config.ViewLevelCommand.Contains(" ")
                    ? config.ViewLevelCommand
                    : throw new ArgumentException("Command contains space")));
            Commands.ChatCommands.Add(new Command(config.RankPermission, LevelUp, config.LevelUpCommand.Contains(" ")
                ? config.LevelUpCommand
                : throw new ArgumentException("Command contains space")));
            Commands.ChatCommands.Add(new Command(config.RankPermission, ClassSelect,
                config.ClassSelectCommand.Contains(" ")
                    ? config.ClassSelectCommand
                    : throw new ArgumentException("Command contains space")));
        }

        private static Dictionary<string, Level> Levels = new Dictionary<string, Level>();

        private void ViewLevel(CommandArgs args)
        {
        }

        private void LevelUp(CommandArgs args)
        {
        }

        private void ClassSelect(CommandArgs args)
        {
        }

        private void Rank(TSPlayer p, string[] args, bool tryLevel)
        {
            if (p.HasPermission(config.RankExcludePermission))
            {
                p.SendInfoMessage(config.Messages["RankExclude"]);
            }

            var nextLevel = config.Levels.Where(l => l.Parents.ContainsKey(p.Group.Name));
            switch (nextLevel.Count())
            {
                case 0:
                {
                    var nl = config.Levels.Single(l => l.Parents.Count == 0);
                    p.SendInfoMessage(tryLevel
                        ? Move(p, nl, Levels[p.Group.Name])
                            ? config.Messages["RankStart"]
                            : config.Messages["RankFail"]
                        : config.Messages["NotInRank"]);
                    break;
                }
                case 1:
                {
                    p.SendInfoMessage(tryLevel
                        ? Move(p, nextLevel.First(), Levels[p.Group.Name])
                            ? config.Messages["RankStart"]
                            : config.Messages["RankFail"]
                        : InfoPlayer(p, nextLevel.First(), Levels[p.Group.Name], config.Messages["ViewLevel"]));
                    break;
                }
                default:
                {
                    if (args.Length > 0)
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
                        }
                    }

                    break;
                }
            }
        }

        private bool Move(TSPlayer p, Level newLevel, Level oldLevel)
        {
            IBankAccount playerAccount = SEconomyPlugin.Instance.GetBankAccount(p);
            if (playerAccount == null || playerAccount.IsAccountEnabled == false ||
                !Money.TryParse(newLevel.Parents[oldLevel.TsGroup], out var commandCost) ||
                playerAccount.Balance < commandCost)
            {
                return false;
            }

            playerAccount.Balance -= commandCost;
            p.Group = TShock.Groups.GetGroupByName(newLevel.TsGroup);
            newLevel.LevelUpCommand.ForEach(f => PLI(TSPlayer.Server, f));
            newLevel.LevelUpInvoke.ForEach(f => PLI(p, f));
            return true;
        }

        private static string InfoPlayer(TSPlayer p, Level nl, Level ol, string s)
        {
            return string.Format(s, p.Name, nl.DisplayName, ol.DisplayName);
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