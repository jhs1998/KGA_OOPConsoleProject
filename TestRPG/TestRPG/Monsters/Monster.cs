using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestRPG.NewFolder;

namespace TestRPG.Monsters
{
    public class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; } 
        public int Mongold { get; set; }
        public int Skillcost { get; set; }
        public int Skill { get; set; }
        public int SkillDamage { get; set; }
        public string SkillName { get; set; }

        public List<MonsterSkill> skills = new List<MonsterSkill>();

        public Monster(string name, int hp, int attack, int defense, int mongold, int skillcost, int skill, int skillDamage, string skillname)
        {
            Name = name;
            HP = hp;           
            Attack = attack;
            Defense = defense;
            Mongold = mongold;
            Skillcost = skillcost;
            Skill = skill;
            SkillDamage = skillDamage;
            SkillName = skillname;
        }

        //아이템 데미지

        //

        //맞았을때 
        public void GetDamage(int damage)
        {
            Console.WriteLine($"{Name}을/를 공격!");
            Thread.Sleep(1000);
            // 데미지를 입었을때 hp에서 데미지를 뺌          
            if (damage > Defense)
            {
                HP = HP - damage + Defense;           
                Console.WriteLine($"{Name}이/가 {damage - Defense} 피해를 입었습니다. 남은 체력: {HP} ");
                Thread.Sleep(1000);
            }
            // 방어가 데미지보다 높을 경우 데미지를 입지 않음
            else if (damage <= Defense)
            {
                HP = HP;
                Console.WriteLine($"{Name}이/가 데미지를 입지 않았습니다.");
                Thread.Sleep(1000);
            }     
            if (HP <= 0)
            {
                HP = 0;
            }           
        }
        public void ItemDamage(int damage)
        {
            Console.WriteLine($"{Name}을/를 공격!");
            Thread.Sleep(1000);
            // 데미지를 입었을때 hp에서 데미지를 뺌          
            HP -= damage;
            Console.WriteLine($"{Name}은 {damage}데미지를 입었습니다.");
            Thread.Sleep(1000);
            if (HP <= 0)
            {
                HP = 0;
            }
        }
    }   
}
