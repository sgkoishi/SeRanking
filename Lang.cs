using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TShockAPI;

namespace Chireiden.SEconomy.Ranking
{
    public static class Lang
    {
        private static string Beginner = "Beginner";
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
        private static string _classSelectCommand = "class";
        private static string _levelUpCommand = "level";
        private static string _rankExcludePermission = "chireiden.rank.exclude";
        private static string _rankPermission = "chireiden.rank.use";
        private static string _viewLevelCommand = "vl";
        private static string _viewLevelPermission = "chireiden.rank.viewlevel";

        private static Dictionary<string, string> _message = new Dictionary<string, string>
        {
            {"RankExclude", "[SeRanking] You can not use the ranking system."},
            {
                "NotInRank",
                $"[SeRanking] You're not in the ranking system, use {TShock.Config.CommandSpecifier}{_levelUpCommand} to join."
            },
            {"RankStart", "[SeRanking] You've join the ranking system."},
            {"ViewLevel", "[SeRanking] Current Level: {0} | Next Level: {1} | Current XP: {2}"},
            {"RankFail", "[SeRanking] Ranking fail."},
            {"NoMatchClass", "[SeRanking] No class match your input."},
            {"MultMatchClass", "[SeRanking] Multiple classes match your input."},
            {"ClassFormat", "* {0}: {1}. Cost {2}."},
            {"Load", "[SeRanking] Load {0} levels and {1} item restrictions."},
            {
                "UseClassInstead",
                $"[SeRanking] It's time to choose a class! Use {TShock.Config.CommandSpecifier}{_classSelectCommand} instead."
            },
            {
                "UseLevelInstead",
                $"[SeRanking] No class to choose! Use {TShock.Config.CommandSpecifier}{_levelUpCommand} instead."
            },
            {"MaxLevel", "[SeRanking] You've reach Max Level!"},
            {"MoreXpRequired", "[SeRanking] You need more XP!"}
        };

        /// <summary>
        ///     This function can be removed if you don't care/want other language.
        /// </summary>
        public static void Init()
        {
            Beginner = "萌新";
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
            _classSelectCommand = "转职";
            _levelUpCommand = "升级";
            _rankExcludePermission = "chireiden.rank.exclude";
            _rankPermission = "chireiden.rank.use";
            _viewLevelCommand = "等级";
            _viewLevelPermission = "chireiden.rank.viewlevel";
            _message = new Dictionary<string, string>
            {
                {"RankExclude", "[SeRanking] 你无法使用等级系统。"},
                {
                    "NotInRank",
                    $"[SeRanking] 你尚未进入等级系统，使用{TShock.Config.CommandSpecifier}{_levelUpCommand}即可进入。"
                },
                {"RankStart", "[SeRanking] 你进入了等级系统。"},
                {"ViewLevel", "[SeRanking] 当前等级: {0} | 下个等级: {1} | 当前经验: {2}"},
                {"RankFail", "[SeRanking] 等级系统错误。"},
                {"NoMatchClass", "[SeRanking] 无法匹配转职目标。"},
                {"MultMatchClass", "[SeRanking] 匹配到多个转职目标。"},
                {"ClassFormat", "* {0}: {1}。消耗 {2}"},
                {"Load", "[SeRanking] 已加载 {0} 个等级和 {1} 个物品限制。"},
                {
                    "UseClassInstead",
                    $"[SeRanking] 该选择一个职业来转职了! 使用{TShock.Config.CommandSpecifier}{_classSelectCommand} 进行转职。"
                },
                {"UseLevelInstead", $"[SeRanking] 没有可以转职的职业！使用{TShock.Config.CommandSpecifier}{_levelUpCommand} 升级。"},
                {"MaxLevel", "[SeRanking] 你已经到达满级了！"},
                {"MoreXpRequired", "[SeRanking] 你需要更多的经验！"}
            };
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
                        ChatColor = Ranking.Color2String(Color.Gray),
                        TsGroup = "default",
                        DisplayName = Beginner,
                        Description = "Description for Beginner",
                        Prefix = Beginner,
                        Parents = new Dictionary<string, string>()
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.White),
                        TsGroup = "adventurer",
                        DisplayName = Adventurer,
                        Description = "Description for Adventurer",
                        Prefix = Adventurer,
                        Parents = new Dictionary<string, string> {{"default", "100"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Fighter),
                        DisplayName = Fighter,
                        Description = "Description for Fighter",
                        Prefix = Fighter,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Novice),
                        DisplayName = Novice,
                        Description = "Description for Novice",
                        Prefix = Novice,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Recruit),
                        DisplayName = Recruit,
                        Description = "Description for Recruit",
                        Prefix = Recruit,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Scout),
                        DisplayName = Scout,
                        Description = "Description for Scout",
                        Prefix = Scout,
                        Parents = new Dictionary<string, string> {{"adventurer", "10000"}}
                    },

                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Cleric),
                        DisplayName = Cleric,
                        Description = "Description for Cleric",
                        Prefix = Cleric,
                        Parents = new Dictionary<string, string> {{"recruit", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Guard),
                        DisplayName = Guard,
                        Description = "Description for Guard",
                        Prefix = Guard,
                        Parents = new Dictionary<string, string> {{"recruit", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Mercenary),
                        DisplayName = Mercenary,
                        Description = "Description for Mercenary",
                        Prefix = Mercenary,
                        Parents = new Dictionary<string, string> {{"fighter", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Monk),
                        DisplayName = Monk,
                        Description = "Description for Monk",
                        Prefix = Monk,
                        Parents = new Dictionary<string, string> {{"novice", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Rogue),
                        DisplayName = Rogue,
                        Description = "Description for Rogue",
                        Prefix = Rogue,
                        Parents = new Dictionary<string, string> {{"scout", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Sage),
                        DisplayName = Sage,
                        Description = "Description for Sage",
                        Prefix = Sage,
                        Parents = new Dictionary<string, string> {{"novice", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Shaman),
                        DisplayName = Shaman,
                        Description = "Description for Shaman",
                        Prefix = Shaman,
                        Parents = new Dictionary<string, string> {{"scout", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Wizard),
                        DisplayName = Wizard,
                        Description = "Description for Wizard",
                        Prefix = Wizard,
                        Parents = new Dictionary<string, string> {{"fighter", "1000000"}}
                    },

                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Assassin),
                        DisplayName = Assassin,
                        Description = "Description for Assassin",
                        Prefix = Assassin,
                        Parents = new Dictionary<string, string> {{"rogue", "10000000"}, {"monk", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Berserker),
                        DisplayName = Berserker,
                        Description = "Description for Berserker",
                        Prefix = Berserker,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"guard", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Champion),
                        DisplayName = Champion,
                        Description = "Description for Champion",
                        Prefix = Champion,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"monk", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Deathknight),
                        DisplayName = Deathknight,
                        Description = "Description for Deathknight",
                        Prefix = Deathknight,
                        Parents = new Dictionary<string, string> {{"mercenary", "10000000"}, {"rogue", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Hierarch),
                        DisplayName = Hierarch,
                        Description = "Description for Hierarch",
                        Prefix = Hierarch,
                        Parents = new Dictionary<string, string> {{"sage", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Inquisitor),
                        DisplayName = Inquisitor,
                        Description = "Description for Inquisitor",
                        Prefix = Inquisitor,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"shaman", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Paladin),
                        DisplayName = Paladin,
                        Description = "Description for Paladin",
                        Prefix = Paladin,
                        Parents = new Dictionary<string, string> {{"monk", "10000000"}, {"guard", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        TsGroup = nameof(Pyromaniac),
                        DisplayName = Pyromaniac,
                        Description = "Description for Pyromaniac",
                        Prefix = Pyromaniac,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"sage", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        TsGroup = nameof(Slayer),
                        DisplayName = Slayer,
                        Description = "Description for Slayer",
                        Prefix = Slayer,
                        Parents = new Dictionary<string, string> {{"shaman", "10000000"}, {"sage", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Summoner),
                        DisplayName = Summoner,
                        Description = "Description for Summoner",
                        Prefix = Summoner,
                        Parents = new Dictionary<string, string> {{"wizard", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        TsGroup = nameof(Warden),
                        DisplayName = Warden,
                        Description = "Description for Warden",
                        Prefix = Warden,
                        Parents = new Dictionary<string, string> {{"shaman", "10000000"}, {"cleric", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        TsGroup = nameof(Warlord),
                        DisplayName = Warlord,
                        Description = "Description for Warlord",
                        Prefix = Warlord,
                        Parents = new Dictionary<string, string> {{"rogue", "10000000"}, {"guard", "10000000"}}
                    }
                }
            };
        }
    }
}