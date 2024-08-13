using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.NewFolder;

namespace TestRPG.Players
{
    public class CorporateSlaves : Player
    {
        public CorporateSlaves(string name)
        {
            this.name = name;
            this.job = Job.CorporateSlaves;
            this.maxHP = 150;
            this.curHP = maxHP;
            this.maxMP = 150;
            this.curMP = maxMP;
            this.attack = 30;
            this.defense = 4;
            this.gold = 1500;

            skills.Add(new PlayerSkill("급속재생", 20, 0, "신체를 회복합니다."));
        }

        public override void Skill(Monster monster)
        {
            if (curMP >= 10)
            {
                Console.WriteLine($"{name}이(가) 스킬사용");
                monster.GetDamage(100);
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
