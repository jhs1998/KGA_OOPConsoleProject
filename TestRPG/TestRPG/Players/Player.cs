using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRPG.NewFolder;
using TestRPG.Monsters;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Players
{
    public abstract class Player
    {
        protected string name;
        public string Name { get { return name; } }

        protected Job job;
        public Job Job { get { return job; } }

        protected int curHP;
        public int CurHP { get { return curHP; } set { curHP = value; } }

        public void PluseCurHP(int amount)
        {
            curHP += amount;
        }
        public void equalCurHP(int amount)
        {
            curHP = amount;
        }
        protected int maxHP;
        public int MaxHP { get { return maxHP; } set { maxHP = value; } }

        protected int curMP;
        public int CurMP { get { return curMP; } set { curMP = value; } }
        public void PluseCurMP(int amount)
        {
            curMP += amount;
        }
        public void equalCurMP(int amount)
        {
            curMP = amount;
        }
        protected int maxMP;
        public int MaxMP { get { return maxMP; } set { maxMP = value; } }

        protected int attack;
        public int Attack { get { return attack; } set { attack = value; } }

        public void PluseAttack(int amount)
        {
            attack += amount;
        }

        protected int defense;
        public int Defense { get { return defense; } set { defense = value; } }

        protected int avoidance;
        public int Avoidance { get { return avoidance; } set { avoidance = value; } }

        protected int trace;
        public int Trace { get { return trace; } set { trace = value; } }

        protected int area;
        public int Area { get { return area; } set { area = value; } }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }
        public void Plusegold(int amount)
        {
            gold += amount;
        }
        public Monster Monster { get; set; }

        public List<PlayerSkill> skills = new List<PlayerSkill>();
        public List<Item> Inventory { get; set; }
        public Player()
        {
            // 다른 속성 초기화
            Inventory = new List<Item>(); // Inventory 리스트 초기화
        }

        public abstract void Skill(Monster monster);
        public abstract void Damage(Monster monster);


        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==========================================");
            Console.WriteLine($" 이름 : {name,-6} 직업 : {job,-6}");
            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}  이성 : {curMP,+3} / {maxMP}");
            Console.WriteLine($" 공격 : {attack,-3} / 내구 : {defense,-3} / 회피 : {avoidance, -3}");
            Console.Write($" 골드 : {gold,+5} G   보유 스킬 : ");
            foreach (var PlayerSkill in skills)
            {
                Console.WriteLine($"{PlayerSkill.Name}");
            }
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }

        public void GetDamage(int damage)
        {
            Console.WriteLine($"{Name}은 공격받았습니다.");
            Thread.Sleep(1000);
            // 데미지를 입었을때 hp에서 데미지를 뺌          
            if (damage > Defense)
            {
                CurHP = CurHP - damage + Defense;
                Console.WriteLine($"{damage - Defense} 피해를 입었습니다.");
                Thread.Sleep(1000);
            }
            // 방어가 데미지보다 높을 경우 데미지를 입지 않음
            else if (damage <= Defense)
            {
                CurHP = CurHP;
                Console.WriteLine($"{Name}이/가 공격을 막아 데미지를 입지 않았습니다.");
                Thread.Sleep(1000);
            }
            if (CurHP <= 0)
            {
                CurHP = 0;
            }
        }
        public void GetSkillDamage(string monstername, int damage, string skillname)
        {
            Console.WriteLine($"{Name}은 공격받았습니다.");
            Thread.Sleep(1000);
            // 데미지를 입었을때 hp에서 데미지를 뺌          
            if (damage > Defense)
            {
                CurHP = CurHP - damage + Defense;
                Console.WriteLine($"{monstername}이 {skillname} 공격을 했습니다.");
                if (monstername == "지부장")
                {
                    Random rand = new Random();
                    int gan = rand.Next(10);
                    Console.WriteLine($"{gan+1}번 발사합니다.");
                    for (int i = 0; i < gan; i++)
                    {
                        Console.WriteLine($"{damage - Defense} 피해를 입었습니다.");
                    }
                }
                Console.WriteLine($"{damage - Defense} 피해를 입었습니다.");
                Thread.Sleep(1000);
            }
            // 방어가 데미지보다 높을 경우 데미지를 입지 않음
            else if (damage <= Defense)
            {
                CurHP = CurHP;
                Console.WriteLine($"{Name}이/가 공격을 막아 데미지를 입지 않았습니다.");
                Thread.Sleep(1000);
            }
            if (CurHP <= 0)
            {
                CurHP = 0;
            }
        }
        

    }
}
