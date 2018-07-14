using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Chireiden.SEconomy.Ranking
{
    public class Level
    {
        internal Level[] _children;
        internal string _cost;
        private string _group = "default";
        internal Level _parent;
        public int[] AllowedItems = new int[0];
        public string ChatColor = Ranking.Color2String(Color.White);
        public string Description = "";

        public string DisplayName = "";
        public string[] LevelUpCommand = new string[0];
        public string[] LevelUpInvoke = new string[0];
        public Dictionary<string, string> Parents = new Dictionary<string, string>();
        public string Prefix = "";
        public string Suffix = "";

        public string TsGroup
        {
            get => _group;
            set => _group = value.ToLower();
        }
    }

    public class Config
    {
        public string ClassSelectCommand = "";
        public Level[] Levels = new Level[0];
        public string LevelUpCommand = "";
        public Dictionary<string, string> Messages = new Dictionary<string, string>();
        public string RankExcludePermission = "";
        public string RankPermission = "";
        public string ViewLevelCommand = "";
        public string ViewLevelPermission = "";
    }
}