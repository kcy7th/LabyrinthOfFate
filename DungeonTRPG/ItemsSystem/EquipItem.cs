﻿using System;
using DungeonTRPG.EntitySystem.Utility;
using DungeonTRPG.ItemsSystem;
using DungeonTRPG.Utility.Enums;

namespace DungeonTRPG.Items
{
    internal class EquipItem : Item
    {
        public ExtraStat ExtraStat { get; }

        public EquipSlot Slot { get; } // 장착 슬롯 정보 추가
        public bool IsEquipped { get; internal set;}

        public EquipItem(string name, string description, int price, List<Job> allowedJobs, ExtraStat extraStat, EquipSlot slot)
            : base(name, description, price, allowedJobs)
        {
            Slot = slot;
            ExtraStat = extraStat;
        }

        // 아이템 복제
        public override Item Clone()
        {
            return new EquipItem(name, description, Price, new List<Job>(AllowedJobs), ExtraStat, Slot);
        }

        public override int CompareTo(Item? other)
        {
            if (other is EquipItem)
            {
                int index = this.AllowedJobs[0].CompareTo(other.AllowedJobs[0]);
                if (index == 0)
                {
                    return this.name.CompareTo(other.GetName());
                }
                else return index;
            }
            else return -1;
        }

        public string GetItemStatToString()
        {
            string s = "";
            if (ExtraStat.Hp > 0) s += $"| 체력 +{ExtraStat.Hp.ToString()} ";
            if (ExtraStat.Mp > 0) s += $"| 마나 +{ExtraStat.Mp.ToString()} ";
            if (ExtraStat.Atk > 0) s += $"| 공격력 +{ExtraStat.Atk.ToString()} ";
            if (ExtraStat.SpellAtk > 0) s += $"| 주문력 +{ExtraStat.SpellAtk.ToString()} ";
            if (ExtraStat.Def > 0) s += $"| 방어력 +{ExtraStat.Def.ToString()} ";
            return s;
        }

        public override string GetItemInformation()
        {
            return $"{name} | {description} {GetItemStatToString()}";
        }
    }
}
