using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;

namespace TestRPG.Players
{
    public class Mage : Player
    {
        public Mage(string name)
        {
            this.name = name;
            this.job = Job.Mage;
            this.maxHP = 60;
            this.curHP = maxHP;
            this.attack = 50;
            this.defense = 10;
            this.gold = 100;
        }

        public override void Skill(Monster monster)
        {
            // TODO : 스킬 구현
        }
    }
}
