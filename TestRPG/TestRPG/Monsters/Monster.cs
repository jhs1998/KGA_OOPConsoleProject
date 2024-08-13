using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG.Monsters
{
    public class Monster
    {
        public string name;
        public int hp;
        public int attack;
        public int defense;


        public void GetDamage(int damage)
        {
            // 데미지를 입었을때 hp에서 데미지를 뺌          
            if (damage > defense)
                hp = hp - damage + defense;
            // 방어가 데미지보다 높을 경우 데미지를 입지 않음
            else if (damage < defense)
                hp = hp;

            if (hp <= 0)
            {
                hp = 0;
                Console.WriteLine($"{name}이(가) 쓰러졌습니다.");
            }
            else if (damage > defense)
            {
                Console.WriteLine($"{name}이(가) {damage - defense} 피해를 입었습니다. 남은 체력: {hp} ");
            }
            else 
            {
                Console.WriteLine("데미지를 입지 않았습니다.");
            }
        }
    }

    
}
