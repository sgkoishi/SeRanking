using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Chireiden.SEconomy.Ranking
{
    public class Level
    {
        private string _group;

        public string TsGroup
        {
            get => _group;
            set => _group = value.ToLower();
        }

        public string DisplayName;
        public string Prefix;
        public string Suffix;
        public Color ChatColor;
        public Dictionary<string, string> Parents;
        public string[] LevelUpInvoke;
        public string[] LevelUpCommand;
        public int[] AllowedItems;
        public int Cost;
    }

    public class Config
    {
        public string ClassSelectCommand;
        public string LevelUpCommand;
        public string RankExcludePermission;
        public string RankPermission;
        public string ViewLevelCommand;
        public string ViewLevelPermission;
        public Dictionary<string, string> Messages;
        public Level[] Levels;
    }
}