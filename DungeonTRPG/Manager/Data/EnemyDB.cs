﻿using DungeonTRPG.Entity.Enemy;
using DungeonTRPG.Entity.Utility;
using DungeonTRPG.Items;
using Newtonsoft.Json;

namespace DungeonTRPG.Manager.Data
{
    internal class EnemyDB
    {
        [JsonProperty]
        public Dictionary<int, Enemy> enemys { get; } = new Dictionary<int, Enemy>()
        {
            { 8000, new Enemy("고블린", 10, new Stat(1, 10, 10, 10, 1, 1)) },
        };

        public Enemy GetByKey(int key)
        {
            if (enemys.ContainsKey(key))
            {
                return enemys[key];
            }
            return null;
        }
    }
}
