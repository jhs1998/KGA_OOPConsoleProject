using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG.NewFolder
{
    public class PlayerSkill
    {
        public string Name { get; private set; } // 스킬 이름
        public int ManaCost { get; private set; } // 마나 소모량
        public int Damage { get; private set; } // 스킬 데미지
        public string Explain { get; private set; } // 스킬 설명

        public PlayerSkill(string name, int manaCost, int damage , string explain)
        {
            Name = name;
            ManaCost = manaCost;
            Damage = damage;
            Explain = explain;
        }
    }
}
