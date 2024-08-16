using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.NewFolder;
using TestRPG.Monsters;
using TestRPG.Players;
using System.Numerics;
using System.Reflection.Emit;

namespace TestRPG
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool UsePasible { get; set; }
        public virtual void Use(Player player, Monster monster)
        { }
    }

    public class EquippedItem : Item
    {
        public int Statpluse { get; set; }

        public EquippedItem(string name, int price, string description, int statpluse)
        {
            Name = name;
            Price = price;
            Description = description;
            Statpluse = statpluse;
            UsePasible = false;
        }
    }

    public class UsingItem : Item
    {
        public int Usin { get; set; }
        public UsingItem(string name, int price, string description, int usin)
        {
            Name = name;
            Price = price;
            Description = description;
            Usin = usin;
            UsePasible = true;
        }
        public override void Use(Player player, Monster monster)
        {
            player.CurHP += Usin;
            if (player.CurHP > player.MaxHP)
            {
                player.CurHP = player.MaxHP;
            }
        }
    }

    public class AttackItem : Item
    {
        public int Damage { get; set; }
        public AttackItem(string name, int price, string description, int damage)
        {
            Name = name;
            Price = price;
            Description = description;
            Damage = damage;
            UsePasible = true;
        }
        public override void Use(Player player, Monster monster)
        {
            Console.WriteLine($"{Name}을 사용해 적에게 {Damage}피해를 주었습니다.");
            monster.HP -= Damage;
        }
    }
}
