using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.NewFolder;

namespace TestRPG.Players
{
    public class StreetKid : Player
    {
        public StreetKid(string name)
        {
            this.name = name;
            this.job = Job.StreetKid;
            this.maxHP = 250;
            this.curHP = maxHP;
            this.maxMP = 40;
            this.curMP = maxMP;
            this.attack = 40;
            this.defense = 8;
            this.gold = 100;

            skills.Add(new PlayerSkill("마구베기", 10, 40, "적을 3번 공격한다."));
        }

        public override void Skill(Monster monster)
        {
            if (curMP >= 10)
            {
                Console.WriteLine($"{name}이(가) 스킬사용");
                monster.GetDamage(attack);
                Thread.Sleep(100);
                monster.GetDamage(attack);
                Thread.Sleep(100);
                monster.GetDamage(attack);
                curMP -= 10;
            }
            else
            {
                Console.WriteLine("이성이 부족하여 스킬 사용이 불가합니다.");
            }
        }
        public override void Damage(Monster monster)
        {
            int non = monster.attack - defense;
            if (non > 0)
            {
                curHP -= non;
                if (curHP <= 0)
                {
                    curHP = 0;
                    Console.WriteLine($"{monster.name}이(가) ({monster.attack}-{defense}) 공격하여 체력이 {curHP}남았습니다.");
                    Console.WriteLine("체력이 0이 되어 사망하였습니다.");
                }
                else if (curHP > 0)
                {
                    Console.WriteLine($"{monster.name}이(가) ({monster.attack}-{defense}) 공격하여 체력이 {curHP}남았습니다.");
                }
            }
            else if (non <= 0)
                non = 0;
            Console.WriteLine($"{monster.name}의 공격이 막혔습니다.");
        }
    }
}
