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
        private static void InitChinese()
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
        /// <summary>
        /// Get a preset config.
        /// </summary>
        public static Config DefaultConfig()
        {
            bool English = true;
            if (!English)
            {
                InitChinese();
            }

            var i = 0;

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
                        LevelUpCommand = new[]
                            {"/firework {0}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = "default",
                        DisplayName = Beginner,
                        Description = "Description for Beginner",
                        Prefix = Beginner,
                        Parents = new Dictionary<string, string>()
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.White),
                        LevelUpCommand = new[]
                            {"/firework {0}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Adventurer) + ++i,
                        DisplayName = $"{Adventurer}[{i}]",
                        Description = "Description for Adventurer " + i,
                        Prefix = $"{Adventurer}[{i}]",
                        Parents = new Dictionary<string, string> {{"default", "100"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.White),
                        LevelUpCommand = new[]
                            {"/firework {0}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Adventurer) + ++i,
                        DisplayName = $"{Adventurer}[{i}]",
                        Description = "Description for Adventurer " + i,
                        Prefix = $"{Adventurer}[{i}]",
                        Parents = new Dictionary<string, string> {{"adventurer" + (i - 1), "100"}}
                    },


                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Fighter) + (i = 1),
                        DisplayName = $"{Fighter}",
                        Description = "Description for Fighter " + i,
                        Prefix = $"{Fighter}[{i}]",
                        Parents = new Dictionary<string, string> {{"adventurer2", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Novice) + i,
                        DisplayName = $"{Novice}",
                        Description = "Description for Novice " + i,
                        Prefix = $"{Novice}[{i}]",
                        Parents = new Dictionary<string, string> {{"adventurer2", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Recruit) + i,
                        DisplayName = $"{Recruit}",
                        Description = "Description for Recruit " + i,
                        Prefix = $"{Recruit}[{i}]",
                        Parents = new Dictionary<string, string> {{"adventurer2", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Scout) + i,
                        DisplayName = $"{Scout}",
                        Description = "Description for Scout " + i,
                        Prefix = $"{Scout}[{i}]",
                        Parents = new Dictionary<string, string> {{"adventurer2", "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Fighter) + ++i,
                        DisplayName = $"{Fighter}[{i}]",
                        Description = "Description for Fighter " + i,
                        Prefix = $"{Fighter}[{i}]",
                        Parents = new Dictionary<string, string> {{"fighter" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Novice) + i,
                        DisplayName = $"{Novice}[{i}]",
                        Description = "Description for Novice " + i,
                        Prefix = $"{Novice}[{i}]",
                        Parents = new Dictionary<string, string> {{"novice" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Recruit) + i,
                        DisplayName = $"{Recruit}[{i}]",
                        Description = "Description for Recruit " + i,
                        Prefix = $"{Recruit}[{i}]",
                        Parents = new Dictionary<string, string> {{"recruit" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Scout) + i,
                        DisplayName = $"{Scout}[{i}]",
                        Description = "Description for Scout " + i,
                        Prefix = $"{Scout}[{i}]",
                        Parents = new Dictionary<string, string> {{"scout" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Fighter) + ++i,
                        DisplayName = $"{Fighter}[{i}]",
                        Description = "Description for Fighter " + i,
                        Prefix = $"{Fighter}[{i}]",
                        Parents = new Dictionary<string, string> {{"fighter" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Novice) + i,
                        DisplayName = $"{Novice}[{i}]",
                        Description = "Description for Novice " + i,
                        Prefix = $"{Novice}[{i}]",
                        Parents = new Dictionary<string, string> {{"novice" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Recruit) + i,
                        DisplayName = $"{Recruit}[{i}]",
                        Description = "Description for Recruit " + i,
                        Prefix = $"{Recruit}[{i}]",
                        Parents = new Dictionary<string, string> {{"recruit" + (i - 1), "10000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Scout) + i,
                        DisplayName = $"{Scout}[{i}]",
                        Description = "Description for Scout " + i,
                        Prefix = $"{Scout}[{i}]",
                        Parents = new Dictionary<string, string> {{"scout" + (i - 1), "10000"}}
                    },


                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Cleric) + (i = 1),
                        DisplayName = $"{Cleric}",
                        Description = "Description for Cleric " + i,
                        Prefix = $"{Cleric}[{i}]",
                        Parents = new Dictionary<string, string> {{"recruit3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Guard) + i,
                        DisplayName = $"{Guard}",
                        Description = "Description for Guard " + i,
                        Prefix = $"{Guard}[{i}]",
                        Parents = new Dictionary<string, string> {{"recruit3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Mercenary) + i,
                        DisplayName = $"{Mercenary}",
                        Description = "Description for Mercenary " + i,
                        Prefix = $"{Mercenary}[{i}]",
                        Parents = new Dictionary<string, string> {{"fighter3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Monk) + i,
                        DisplayName = $"{Monk}",
                        Description = "Description for Monk " + i,
                        Prefix = $"{Monk}[{i}]",
                        Parents = new Dictionary<string, string> {{"novice3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Rogue) + i,
                        DisplayName = $"{Rogue}",
                        Description = "Description for Rogue " + i,
                        Prefix = $"{Rogue}[{i}]",
                        Parents = new Dictionary<string, string> {{"scout3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Sage) + i,
                        DisplayName = $"{Sage}",
                        Description = "Description for Sage " + i,
                        Prefix = $"{Sage}[{i}]",
                        Parents = new Dictionary<string, string> {{"novice3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Shaman) + i,
                        DisplayName = $"{Shaman}",
                        Description = "Description for Shaman " + i,
                        Prefix = $"{Shaman}[{i}]",
                        Parents = new Dictionary<string, string> {{"scout3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Wizard) + i,
                        DisplayName = $"{Wizard}",
                        Description = "Description for Wizard " + i,
                        Prefix = $"{Wizard}[{i}]",
                        Parents = new Dictionary<string, string> {{"fighter3", "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Cleric) + ++i,
                        DisplayName = $"{Cleric}[{i}]",
                        Description = "Description for Cleric " + i,
                        Prefix = $"{Cleric}[{i}]",
                        Parents = new Dictionary<string, string> {{"cleric" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Guard) + i,
                        DisplayName = $"{Guard}[{i}]",
                        Description = "Description for Guard " + i,
                        Prefix = $"{Guard}[{i}]",
                        Parents = new Dictionary<string, string> {{"guard" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Mercenary) + i,
                        DisplayName = $"{Mercenary}[{i}]",
                        Description = "Description for Mercenary " + i,
                        Prefix = $"{Mercenary}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Monk) + i,
                        DisplayName = $"{Monk}[{i}]",
                        Description = "Description for Monk " + i,
                        Prefix = $"{Monk}[{i}]",
                        Parents = new Dictionary<string, string> {{"monk" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Rogue) + i,
                        DisplayName = $"{Rogue}[{i}]",
                        Description = "Description for Rogue " + i,
                        Prefix = $"{Rogue}[{i}]",
                        Parents = new Dictionary<string, string> {{"rogue" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Sage) + i,
                        DisplayName = $"{Sage}[{i}]",
                        Description = "Description for Sage " + i,
                        Prefix = $"{Sage}[{i}]",
                        Parents = new Dictionary<string, string> {{"sage" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Shaman) + i,
                        DisplayName = $"{Shaman}[{i}]",
                        Description = "Description for Shaman " + i,
                        Prefix = $"{Shaman}[{i}]",
                        Parents = new Dictionary<string, string> {{"shaman" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Wizard) + i,
                        DisplayName = $"{Wizard}[{i}]",
                        Description = "Description for Wizard " + i,
                        Prefix = $"{Wizard}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Cleric) + ++i,
                        DisplayName = $"{Cleric}[{i}]",
                        Description = "Description for Cleric " + i,
                        Prefix = $"{Cleric}[{i}]",
                        Parents = new Dictionary<string, string> {{"cleric" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Guard) + i,
                        DisplayName = $"{Guard}[{i}]",
                        Description = "Description for Guard " + i,
                        Prefix = $"{Guard}[{i}]",
                        Parents = new Dictionary<string, string> {{"guard" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Mercenary) + i,
                        DisplayName = $"{Mercenary}[{i}]",
                        Description = "Description for Mercenary " + i,
                        Prefix = $"{Mercenary}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Monk) + i,
                        DisplayName = $"{Monk}[{i}]",
                        Description = "Description for Monk " + i,
                        Prefix = $"{Monk}[{i}]",
                        Parents = new Dictionary<string, string> {{"monk" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Rogue) + i,
                        DisplayName = $"{Rogue}[{i}]",
                        Description = "Description for Rogue " + i,
                        Prefix = $"{Rogue}[{i}]",
                        Parents = new Dictionary<string, string> {{"rogue" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Sage) + i,
                        DisplayName = $"{Sage}[{i}]",
                        Description = "Description for Sage " + i,
                        Prefix = $"{Sage}[{i}]",
                        Parents = new Dictionary<string, string> {{"sage" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Shaman) + i,
                        DisplayName = $"{Shaman}[{i}]",
                        Description = "Description for Shaman " + i,
                        Prefix = $"{Shaman}[{i}]",
                        Parents = new Dictionary<string, string> {{"shaman" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Wizard) + i,
                        DisplayName = $"{Wizard}[{i}]",
                        Description = "Description for Wizard " + i,
                        Prefix = $"{Wizard}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Cleric) + ++i,
                        DisplayName = $"{Cleric}[{i}]",
                        Description = "Description for Cleric " + i,
                        Prefix = $"{Cleric}[{i}]",
                        Parents = new Dictionary<string, string> {{"cleric" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Guard) + i,
                        DisplayName = $"{Guard}[{i}]",
                        Description = "Description for Guard " + i,
                        Prefix = $"{Guard}[{i}]",
                        Parents = new Dictionary<string, string> {{"guard" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Mercenary) + i,
                        DisplayName = $"{Mercenary}[{i}]",
                        Description = "Description for Mercenary " + i,
                        Prefix = $"{Mercenary}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Monk) + i,
                        DisplayName = $"{Monk}[{i}]",
                        Description = "Description for Monk " + i,
                        Prefix = $"{Monk}[{i}]",
                        Parents = new Dictionary<string, string> {{"monk" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Rogue) + i,
                        DisplayName = $"{Rogue}[{i}]",
                        Description = "Description for Rogue " + i,
                        Prefix = $"{Rogue}[{i}]",
                        Parents = new Dictionary<string, string> {{"rogue" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Sage) + i,
                        DisplayName = $"{Sage}[{i}]",
                        Description = "Description for Sage " + i,
                        Prefix = $"{Sage}[{i}]",
                        Parents = new Dictionary<string, string> {{"sage" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Shaman) + i,
                        DisplayName = $"{Shaman}[{i}]",
                        Description = "Description for Shaman " + i,
                        Prefix = $"{Shaman}[{i}]",
                        Parents = new Dictionary<string, string> {{"shaman" + (i - 1), "1000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Wizard) + i,
                        DisplayName = $"{Wizard}[{i}]",
                        Description = "Description for Wizard " + i,
                        Prefix = $"{Wizard}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard" + (i - 1), "1000000"}}
                    },


                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Assassin) + (i = 1),
                        DisplayName = $"{Assassin}",
                        Description = "Description for Assassin " + i,
                        Prefix = $"{Assassin}[{i}]",
                        Parents = new Dictionary<string, string> {{"rogue4", "10000000"}, {"monk4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Berserker) + i,
                        DisplayName = $"{Berserker}",
                        Description = "Description for Berserker " + i,
                        Prefix = $"{Berserker}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary4", "10000000"}, {"guard4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Champion) + i,
                        DisplayName = $"{Champion}",
                        Description = "Description for Champion " + i,
                        Prefix = $"{Champion}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary4", "10000000"}, {"monk4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Deathknight) + i,
                        DisplayName = $"{Deathknight}",
                        Description = "Description for Deathknight " + i,
                        Prefix = $"{Deathknight}[{i}]",
                        Parents = new Dictionary<string, string> {{"mercenary4", "10000000"}, {"rogue4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Hierarch) + i,
                        DisplayName = $"{Hierarch}",
                        Description = "Description for Hierarch " + i,
                        Prefix = $"{Hierarch}[{i}]",
                        Parents = new Dictionary<string, string> {{"sage4", "10000000"}, {"cleric4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Inquisitor) + i,
                        DisplayName = $"{Inquisitor}",
                        Description = "Description for Inquisitor " + i,
                        Prefix = $"{Inquisitor}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard4", "10000000"}, {"shaman4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Paladin) + i,
                        DisplayName = $"{Paladin}",
                        Description = "Description for Paladin " + i,
                        Prefix = $"{Paladin}[{i}]",
                        Parents = new Dictionary<string, string> {{"monk4", "10000000"}, {"guard4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Pyromaniac) + i,
                        DisplayName = $"{Pyromaniac}",
                        Description = "Description for Pyromaniac " + i,
                        Prefix = $"{Pyromaniac}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard4", "10000000"}, {"sage4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Slayer) + i,
                        DisplayName = $"{Slayer}",
                        Description = "Description for Slayer " + i,
                        Prefix = $"{Slayer}[{i}]",
                        Parents = new Dictionary<string, string> {{"shaman4", "10000000"}, {"sage4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Summoner) + i,
                        DisplayName = $"{Summoner}",
                        Description = "Description for Summoner " + i,
                        Prefix = $"{Summoner}[{i}]",
                        Parents = new Dictionary<string, string> {{"wizard4", "10000000"}, {"cleric4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warden) + i,
                        DisplayName = $"{Warden}",
                        Description = "Description for Warden " + i,
                        Prefix = $"{Warden}[{i}]",
                        Parents = new Dictionary<string, string> {{"shaman4", "10000000"}, {"cleric4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warlord) + i,
                        DisplayName = $"{Warlord}",
                        Description = "Description for Warlord " + i,
                        Prefix = $"{Warlord}[{i}]",
                        Parents = new Dictionary<string, string> {{"rogue4", "10000000"}, {"guard4", "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Assassin) + ++i,
                        DisplayName = $"{Assassin}[{i}]",
                        Description = "Description for Assassin " + i,
                        Prefix = $"{Assassin}[{i}]",
                        Parents = new Dictionary<string, string> {{"assassin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Berserker) + i,
                        DisplayName = $"{Berserker}[{i}]",
                        Description = "Description for Berserker " + i,
                        Prefix = $"{Berserker}[{i}]",
                        Parents = new Dictionary<string, string> {{"berserker" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Champion) + i,
                        DisplayName = $"{Champion}[{i}]",
                        Description = "Description for Champion " + i,
                        Prefix = $"{Champion}[{i}]",
                        Parents = new Dictionary<string, string> {{"champion" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Deathknight) + i,
                        DisplayName = $"{Deathknight}[{i}]",
                        Description = "Description for Deathknight " + i,
                        Prefix = $"{Deathknight}[{i}]",
                        Parents = new Dictionary<string, string> {{"deathknight" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Hierarch) + i,
                        DisplayName = $"{Hierarch}[{i}]",
                        Description = "Description for Hierarch " + i,
                        Prefix = $"{Hierarch}[{i}]",
                        Parents = new Dictionary<string, string> {{"hierarch" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Inquisitor) + i,
                        DisplayName = $"{Inquisitor}[{i}]",
                        Description = "Description for Inquisitor " + i,
                        Prefix = $"{Inquisitor}[{i}]",
                        Parents = new Dictionary<string, string> {{"inquisitor" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Paladin) + i,
                        DisplayName = $"{Paladin}[{i}]",
                        Description = "Description for Paladin " + i,
                        Prefix = $"{Paladin}[{i}]",
                        Parents = new Dictionary<string, string> {{"paladin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Pyromaniac) + i,
                        DisplayName = $"{Pyromaniac}[{i}]",
                        Description = "Description for Pyromaniac " + i,
                        Prefix = $"{Pyromaniac}[{i}]",
                        Parents = new Dictionary<string, string> {{"pyromaniac" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Slayer) + i,
                        DisplayName = $"{Slayer}[{i}]",
                        Description = "Description for Slayer " + i,
                        Prefix = $"{Slayer}[{i}]",
                        Parents = new Dictionary<string, string> {{"slayer" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Summoner) + i,
                        DisplayName = $"{Summoner}[{i}]",
                        Description = "Description for Summoner " + i,
                        Prefix = $"{Summoner}[{i}]",
                        Parents = new Dictionary<string, string> {{"summoner" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warden) + i,
                        DisplayName = $"{Warden}[{i}]",
                        Description = "Description for Warden " + i,
                        Prefix = $"{Warden}[{i}]",
                        Parents = new Dictionary<string, string> {{"warden" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warlord) + i,
                        DisplayName = $"{Warlord}[{i}]",
                        Description = "Description for Warlord " + i,
                        Prefix = $"{Warlord}[{i}]",
                        Parents = new Dictionary<string, string> {{"warlord" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Assassin) + ++i,
                        DisplayName = $"{Assassin}[{i}]",
                        Description = "Description for Assassin " + i,
                        Prefix = $"{Assassin}[{i}]",
                        Parents = new Dictionary<string, string> {{"assassin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Berserker) + i,
                        DisplayName = $"{Berserker}[{i}]",
                        Description = "Description for Berserker " + i,
                        Prefix = $"{Berserker}[{i}]",
                        Parents = new Dictionary<string, string> {{"berserker" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Champion) + i,
                        DisplayName = $"{Champion}[{i}]",
                        Description = "Description for Champion " + i,
                        Prefix = $"{Champion}[{i}]",
                        Parents = new Dictionary<string, string> {{"champion" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Deathknight) + i,
                        DisplayName = $"{Deathknight}[{i}]",
                        Description = "Description for Deathknight " + i,
                        Prefix = $"{Deathknight}[{i}]",
                        Parents = new Dictionary<string, string> {{"deathknight" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Hierarch) + i,
                        DisplayName = $"{Hierarch}[{i}]",
                        Description = "Description for Hierarch " + i,
                        Prefix = $"{Hierarch}[{i}]",
                        Parents = new Dictionary<string, string> {{"hierarch" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Inquisitor) + i,
                        DisplayName = $"{Inquisitor}[{i}]",
                        Description = "Description for Inquisitor " + i,
                        Prefix = $"{Inquisitor}[{i}]",
                        Parents = new Dictionary<string, string> {{"inquisitor" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Paladin) + i,
                        DisplayName = $"{Paladin}[{i}]",
                        Description = "Description for Paladin " + i,
                        Prefix = $"{Paladin}[{i}]",
                        Parents = new Dictionary<string, string> {{"paladin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Pyromaniac) + i,
                        DisplayName = $"{Pyromaniac}[{i}]",
                        Description = "Description for Pyromaniac " + i,
                        Prefix = $"{Pyromaniac}[{i}]",
                        Parents = new Dictionary<string, string> {{"pyromaniac" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Slayer) + i,
                        DisplayName = $"{Slayer}[{i}]",
                        Description = "Description for Slayer " + i,
                        Prefix = $"{Slayer}[{i}]",
                        Parents = new Dictionary<string, string> {{"slayer" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Summoner) + i,
                        DisplayName = $"{Summoner}[{i}]",
                        Description = "Description for Summoner " + i,
                        Prefix = $"{Summoner}[{i}]",
                        Parents = new Dictionary<string, string> {{"summoner" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warden) + i,
                        DisplayName = $"{Warden}[{i}]",
                        Description = "Description for Warden " + i,
                        Prefix = $"{Warden}[{i}]",
                        Parents = new Dictionary<string, string> {{"warden" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warlord) + i,
                        DisplayName = $"{Warlord}[{i}]",
                        Description = "Description for Warlord " + i,
                        Prefix = $"{Warlord}[{i}]",
                        Parents = new Dictionary<string, string> {{"warlord" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Assassin) + ++i,
                        DisplayName = $"{Assassin}[{i}]",
                        Description = "Description for Assassin " + i,
                        Prefix = $"{Assassin}[{i}]",
                        Parents = new Dictionary<string, string> {{"assassin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Berserker) + i,
                        DisplayName = $"{Berserker}[{i}]",
                        Description = "Description for Berserker " + i,
                        Prefix = $"{Berserker}[{i}]",
                        Parents = new Dictionary<string, string> {{"berserker" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Champion) + i,
                        DisplayName = $"{Champion}[{i}]",
                        Description = "Description for Champion " + i,
                        Prefix = $"{Champion}[{i}]",
                        Parents = new Dictionary<string, string> {{"champion" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Deathknight) + i,
                        DisplayName = $"{Deathknight}[{i}]",
                        Description = "Description for Deathknight " + i,
                        Prefix = $"{Deathknight}[{i}]",
                        Parents = new Dictionary<string, string> {{"deathknight" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Hierarch) + i,
                        DisplayName = $"{Hierarch}[{i}]",
                        Description = "Description for Hierarch " + i,
                        Prefix = $"{Hierarch}[{i}]",
                        Parents = new Dictionary<string, string> {{"hierarch" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Inquisitor) + i,
                        DisplayName = $"{Inquisitor}[{i}]",
                        Description = "Description for Inquisitor " + i,
                        Prefix = $"{Inquisitor}[{i}]",
                        Parents = new Dictionary<string, string> {{"inquisitor" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Paladin) + i,
                        DisplayName = $"{Paladin}[{i}]",
                        Description = "Description for Paladin " + i,
                        Prefix = $"{Paladin}[{i}]",
                        Parents = new Dictionary<string, string> {{"paladin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Pyromaniac) + i,
                        DisplayName = $"{Pyromaniac}[{i}]",
                        Description = "Description for Pyromaniac " + i,
                        Prefix = $"{Pyromaniac}[{i}]",
                        Parents = new Dictionary<string, string> {{"pyromaniac" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Slayer) + i,
                        DisplayName = $"{Slayer}[{i}]",
                        Description = "Description for Slayer " + i,
                        Prefix = $"{Slayer}[{i}]",
                        Parents = new Dictionary<string, string> {{"slayer" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Summoner) + i,
                        DisplayName = $"{Summoner}[{i}]",
                        Description = "Description for Summoner " + i,
                        Prefix = $"{Summoner}[{i}]",
                        Parents = new Dictionary<string, string> {{"summoner" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warden) + i,
                        DisplayName = $"{Warden}[{i}]",
                        Description = "Description for Warden " + i,
                        Prefix = $"{Warden}[{i}]",
                        Parents = new Dictionary<string, string> {{"warden" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warlord) + i,
                        DisplayName = $"{Warlord}[{i}]",
                        Description = "Description for Warlord " + i,
                        Prefix = $"{Warlord}[{i}]",
                        Parents = new Dictionary<string, string> {{"warlord" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Assassin) + ++i,
                        DisplayName = $"{Assassin}[{i}]",
                        Description = "Description for Assassin " + i,
                        Prefix = $"{Assassin}[{i}]",
                        Parents = new Dictionary<string, string> {{"assassin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Berserker) + i,
                        DisplayName = $"{Berserker}[{i}]",
                        Description = "Description for Berserker " + i,
                        Prefix = $"{Berserker}[{i}]",
                        Parents = new Dictionary<string, string> {{"berserker" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Champion) + i,
                        DisplayName = $"{Champion}[{i}]",
                        Description = "Description for Champion " + i,
                        Prefix = $"{Champion}[{i}]",
                        Parents = new Dictionary<string, string> {{"champion" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Deathknight) + i,
                        DisplayName = $"{Deathknight}[{i}]",
                        Description = "Description for Deathknight " + i,
                        Prefix = $"{Deathknight}[{i}]",
                        Parents = new Dictionary<string, string> {{"deathknight" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Hierarch) + i,
                        DisplayName = $"{Hierarch}[{i}]",
                        Description = "Description for Hierarch " + i,
                        Prefix = $"{Hierarch}[{i}]",
                        Parents = new Dictionary<string, string> {{"hierarch" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Inquisitor) + i,
                        DisplayName = $"{Inquisitor}[{i}]",
                        Description = "Description for Inquisitor " + i,
                        Prefix = $"{Inquisitor}[{i}]",
                        Parents = new Dictionary<string, string> {{"inquisitor" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Paladin) + i,
                        DisplayName = $"{Paladin}[{i}]",
                        Description = "Description for Paladin " + i,
                        Prefix = $"{Paladin}[{i}]",
                        Parents = new Dictionary<string, string> {{"paladin" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Red),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Red)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Pyromaniac) + i,
                        DisplayName = $"{Pyromaniac}[{i}]",
                        Description = "Description for Pyromaniac " + i,
                        Prefix = $"{Pyromaniac}[{i}]",
                        Parents = new Dictionary<string, string> {{"pyromaniac" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Blue),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Blue)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Slayer) + i,
                        DisplayName = $"{Slayer}[{i}]",
                        Description = "Description for Slayer " + i,
                        Prefix = $"{Slayer}[{i}]",
                        Parents = new Dictionary<string, string> {{"slayer" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Summoner) + i,
                        DisplayName = $"{Summoner}[{i}]",
                        Description = "Description for Summoner " + i,
                        Prefix = $"{Summoner}[{i}]",
                        Parents = new Dictionary<string, string> {{"summoner" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Green),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Green)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warden) + i,
                        DisplayName = $"{Warden}[{i}]",
                        Description = "Description for Warden " + i,
                        Prefix = $"{Warden}[{i}]",
                        Parents = new Dictionary<string, string> {{"warden" + (i - 1), "10000000"}}
                    },
                    new Level
                    {
                        ChatColor = Ranking.Color2String(Color.Yellow),
                        LevelUpCommand = new[]
                            {$"/firework {{0}} {nameof(Color.Yellow)}", "/bc {0} spend {3} XP to become {2}!"},
                        TsGroup = nameof(Warlord) + i,
                        DisplayName = $"{Warlord}[{i}]",
                        Description = "Description for Warlord " + i,
                        Prefix = $"{Warlord}[{i}]",
                        Parents = new Dictionary<string, string> {{"warlord" + (i - 1), "10000000"}}
                    }
                }
            };
        }
    }
}