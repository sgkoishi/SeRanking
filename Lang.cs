using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TShockAPI;

namespace Chireiden.SEconomy.Ranking
{
    public static class Lang
    {
        private static string Adventurer = "Adventurer";
        private static string Fighter = "Fighter";
        private static string Novice = "Novice";
        private static string Scout = "Scout";
        private static string Recruit = "Recruit";
        private static string Mercenary = "Mercenary";
        private static string Wizard = "Wizard";
        private static string Monk = "Monk";
        private static string Sage = "Sage";
        private static string Rogue = "Rogue";
        private static string Shaman = "Shaman";
        private static string Guard = "Guard";
        private static string Cleric = "Cleric";
        private static string Berserker = "Berserker";
        private static string Deathknight = "Deathknight";
        private static string Champion = "Champion";
        private static string Pyromaniac = "Pyromaniac";
        private static string Assassin = "Assassin";
        private static string Warden = "Warden";
        private static string Paladin = "Paladin";
        private static string Hierarch = "Hierarch";
        private static string Summoner = "Summoner";
        private static string Slayer = "Slayer";
        private static string Inquisitor = "Inquisitor";
        private static string Warlord = "Warlord";
        private static readonly string _classSelectCommand = "class";
        private static readonly string _levelUpCommand = "level";
        private static readonly string _rankExcludePermission = "chireiden.rank.exclude";
        private static readonly string _rankPermission = "chireiden.rank.use";
        private static readonly string _viewLevelCommand = "vl";
        private static readonly string _viewLevelPermission = "chireiden.rank.viewlevel";

        private static Dictionary<string, string> _message = new Dictionary<string, string>
        {
            {"RankExclude", "You can not use the ranking system."},
            {
                "NotInRank",
                $"You're not in the ranking system, use {TShock.Config.CommandSpecifier}{_levelUpCommand} to join."
            },
            {"RankStart", "You've join the ranking system."},
            {"ViewLevel", "Current Level: {0} | Next Level: {1} | Current XP: {2}"},
            {"RankFail", "Ranking fail."},
            {"NoMatchClass", "No class match your input."},
            {"MultMatchClass", "Multiple classes match your input."},
        };

        /// <summary>
        ///     This function can be removed if you don't care/want other language.
        /// </summary>
        public static void Init()
        {
            Adventurer = "冒险者";
            Fighter = "战士";
            Novice = "法师";
            Scout = "盗贼";
            Recruit = "牧师";
            Mercenary = "狂战士";
            Wizard = "血法师";
            Monk = "武僧";
            Sage = "巫师";
            Rogue = "刺客";
            Shaman = "萨满";
            Guard = "骑士";
            Cleric = "祭司";
            Berserker = "野蛮人";
            Deathknight = "死亡骑士";
            Champion = "恶魔猎手";
            Pyromaniac = "魔导师";
            Assassin = "游侠";
            Warden = "元素领主";
            Paladin = "圣骑士";
            Hierarch = "主教";
            Summoner = "德鲁伊";
            Slayer = "占星术士";
            Inquisitor = "死灵法师";
            Warlord = "守望者";
            _message = new Dictionary<string, string>();
        }

        public static Config DefaultConfig(bool en = true)
        {
            if (!en)
            {
                Init();
            }
            return new Config
            {
                ClassSelectCommand = _classSelectCommand,
                LevelUpCommand = _levelUpCommand,
                RankExcludePermission = _rankExcludePermission,
                RankPermission = _rankPermission,
                Messages = _message,
                ViewLevelCommand = _viewLevelCommand,
                ViewLevelPermission = _viewLevelPermission,
                // This level system is from Estiah(http://www.estiah.com) and fan-made game Linodas(http://www.linodas.com)
                Levels = new[]
                {
                    new Level
                    {
                        ChatColor = Color.Gray,
                        Cost = 0,
                        TsGroup = "default",
                        DisplayName = Adventurer,
                        Prefix = Adventurer
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Fighter),
                        DisplayName = Fighter,
                        Prefix = Fighter,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Novice),
                        DisplayName = Novice,
                        Prefix = Novice,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Recruit),
                        DisplayName = Recruit,
                        Prefix = Recruit,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Scout),
                        DisplayName = Scout,
                        Prefix = Scout,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },

                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Cleric),
                        DisplayName = Cleric,
                        Prefix = Cleric,
                        Parents = new Dictionary<string, string> {{"recruit", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Guard),
                        DisplayName = Guard,
                        Prefix = Guard,
                        Parents = new Dictionary<string, string> {{"recruit", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Mercenary),
                        DisplayName = Mercenary,
                        Prefix = Mercenary,
                        Parents = new Dictionary<string, string> {{"fighter", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Monk),
                        DisplayName = Monk,
                        Prefix = Monk,
                        Parents = new Dictionary<string, string> {{"novice", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Rogue),
                        DisplayName = Rogue,
                        Prefix = Rogue,
                        Parents = new Dictionary<string, string> {{"scout", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Sage),
                        DisplayName = Sage,
                        Prefix = Sage,
                        Parents = new Dictionary<string, string> {{"novice", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Shaman),
                        DisplayName = Shaman,
                        Prefix = Shaman,
                        Parents = new Dictionary<string, string> {{"scout", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Wizard),
                        DisplayName = Wizard,
                        Prefix = Wizard,
                        Parents = new Dictionary<string, string> {{"fighter", "1000000"}}
                    },

                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Assassin),
                        DisplayName = Assassin,
                        Prefix = Assassin,
                        Parents = new Dictionary<string, string> {{"rogue", "10000000"}, {"monk", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Berserker),
                        DisplayName = Berserker,
                        Prefix = Berserker,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"guard", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Champion),
                        DisplayName = Champion,
                        Prefix = Champion,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"monk", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Deathknight),
                        DisplayName = Deathknight,
                        Prefix = Deathknight,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"rogue", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Hierarch),
                        DisplayName = Hierarch,
                        Prefix = Hierarch,
                        Parents = new Dictionary<string, string> {{"sage", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Inquisitor),
                        DisplayName = Inquisitor,
                        Prefix = Inquisitor,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"shaman", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Paladin),
                        DisplayName = Paladin,
                        Prefix = Paladin,
                        Parents = new Dictionary<string, string> {{"monk", "10000000"}, {"guard", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Red,
                        TsGroup = nameof(Pyromaniac),
                        DisplayName = Pyromaniac,
                        Prefix = Pyromaniac,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"sage", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Blue,
                        TsGroup = nameof(Slayer),
                        DisplayName = Slayer,
                        Prefix = Slayer,
                        Parents = new Dictionary<string, string> {{"shaman", "10000000"}, {"sage", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Summoner),
                        DisplayName = Summoner,
                        Prefix = Summoner,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Green,
                        TsGroup = nameof(Warden),
                        DisplayName = Warden,
                        Prefix = Warden,
                        Parents = new Dictionary<string, string> {{"shaman", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Color.Yellow,
                        TsGroup = nameof(Warlord),
                        DisplayName = Warlord,
                        Prefix = Warlord,
                        Parents = new Dictionary<string, string> {{"rogue", "10000000"}, {"guard", "10000000"}}
                    }
                }
            };
        }
    }
}