using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.NewFolder;

namespace TestRPG.Players
{
    public class Nomad : Player
    {
        public Nomad(string name)
        {
            this.name = name;
            this.job = Job.Nomad;
            this.maxHP = 300;
            this.curHP = maxHP;
            this.maxMP = 40;
            this.curMP = maxMP;
            this.attack = 20;
            this.defense = 5;
            this.avoidance = 3;
            this.trace = 0;
            this.Area = 0;
            this.gold = 500;

            skills.Add(new PlayerSkill("훔치기", 10, 0, "적이 가진 골드를 훔친다."));
        }

        public override void Skill(Monster monster)
        {
            if (curMP >= 10)
            {
                Console.WriteLine($"{name}이(가) 스킬사용");
                gold += monster.Defense *123;
                curMP -= 10;
                if (monster.Defense * 123 != 0)
                    Console.WriteLine($"{monster.Defense * 123} G 를 얻었다.");
                else
                    Console.WriteLine($"{monster.Name}에게 돈을 훔치는데 실패했다.");

            }
            else
            {
                Console.WriteLine("이성이 부족하여 스킬 사용이 불가합니다.");
            }
        }
        public override void Damage(Monster monster)
        {
            int non = monster.Attack - defense;
            if (non > 0)
            {
                curHP -= non;
                if (curHP <= 0)
                {
                    curHP = 0;
                    Console.WriteLine($"{monster.Name}이(가) ({monster.Attack}-{defense}) 공격하여 체력이 {curHP}남았습니다.");
                    Console.WriteLine("체력이 0이 되어 사망하였습니다.");
                }
                else if (curHP > 0)
                {
                    Console.WriteLine($"{monster.Name}이(가) ({monster.Attack}-{defense}) 공격하여 체력이 {curHP}남았습니다.");
                }
            }
            else if (non <= 0)
                non = 0;
            Console.WriteLine($"{monster.Name}의 공격이 막혔습니다.");
        }
    }
}
