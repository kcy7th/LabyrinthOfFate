﻿using DungeonTRPG.EntitySystem.Utility;
using DungeonTRPG.EntitySystem.ActiveEffect;
using DungeonTRPG.EntitySystem.SkillSystem;
using DungeonTRPG.Interface;
using DungeonTRPG.Items;
using DungeonTRPG.Manager;
using DungeonTRPG.StateMachineSystem;
using DungeonTRPG.StateMachineSystem.SceneStates.PlayerScene;
using DungeonTRPG.Utility.Enums;
using DungeonTRPG.EntitySystem;
using System.Runtime.InteropServices;

namespace DungeonTRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player", 1500, new Stat(1, 10, 100, 100, 1, 1, 1), Job.Archer);
            EquipItem item1 = GameManager.Instance.DataManager.GameData.EquipItemDB.GetByKey(2001);
            EquipItem item2 = GameManager.Instance.DataManager.GameData.EquipItemDB.GetByKey(4000);
            EquipItem item3 = GameManager.Instance.DataManager.GameData.EquipItemDB.GetByKey(4001);
            ActiveItem item4 = GameManager.Instance.DataManager.GameData.ActiveItemDB.GetByKey(1000);
            ActiveItem item5 = GameManager.Instance.DataManager.GameData.ActiveItemDB.GetByKey(1004);
            ActiveItem item7 = GameManager.Instance.DataManager.GameData.ActiveItemDB.GetByKey(1020);
            ActiveItem item6 = new ActiveItem("기술머신", "아이템을 사용하면 스킬을 배울 수 있다.", 5000, new List<Job>() { Job.Warrior }, new List<IEffect>() { new LearnSkill(new Skill("몸통 박치기", "적에게 10의 피해를 입힌다.", new List<IEffect>() { new HpDamageFixed(20) }, 5)) }, UseableIn.OnlyIdle, true);
            player.Inventory.AddItem(item1);
            player.Inventory.AddItem(item2);
            player.Inventory.AddItem(item4);
            player.Inventory.AddItem(item4);
            player.Inventory.AddItem(item4);
            player.Inventory.AddItem(item4);
            player.Inventory.AddItem(item5);
            player.Inventory.AddItem(item6);
            player.Inventory.AddItem(item7);
            player.Inventory.AddItem(item3);

            StateMachine machine = new StateMachine(player);

            machine.ChangeState(new CreatePlayerScene(machine));

            while (!machine.isGameOver)
            {
                machine.Update();
            }
        }
    }
}
