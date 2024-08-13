using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.NewFolder;
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
        public int CurHP { get { return curHP; } }

        protected int maxHP;
        public int MaxHP { get { return maxHP; } }

        protected int curMP;
        public int CurMP { get { return curMP; } }

        protected int maxMP;
        public int MaxMP { get { return maxMP; } }

        protected int attack;
        public int Attack { get { return attack; } }

        protected int defense;
        public int Defense { get { return defense; } }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        public List<PlayerSkill> skills = new List<PlayerSkill>();
        public abstract void Skill(Monster monster);
        public abstract void Damage(Monster monster);


        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==========================================");
            Console.WriteLine($" 이름 : {name,-6} 직업 : {job,-6}");
            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}  이성 : {curMP,+3} / {maxMP}");
            Console.WriteLine($" 공격 : {attack,-3} / 내구 : {defense,-3}");
            Console.Write($" 골드 : {gold,+5} G   보유 스킬 : ");
            foreach (var PlayerSkill in skills)
            {
                Console.WriteLine($"{PlayerSkill.Name}");
            }
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }
    }
}
