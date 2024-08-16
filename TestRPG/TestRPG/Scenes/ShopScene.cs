using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;


namespace TestRPG.Scenes
{
    public class ShopScene : Scene
    {
        private List<Item> itemslist = new List<Item>();
        public ShopScene(Game game) : base(game)
        {
            itemslist.Add(new EquippedItem("총", 400, "평범한 총이다. 소지시 공격 +3", 3));
            itemslist.Add(new EquippedItem("방탄 조끼", 500, "튼튼한 재질의 조끼이다 소지시 내구 +2", 2));
            itemslist.Add(new UsingItem("폭탄", 200, "적에게 던져 피해를 입힌다. 적에게 사용시 50데미지", 50));
            itemslist.Add(new UsingItem("회복키트", 300, "몸에 좋은 약이다. 사용시 50체력 회복", 50));
        }

        public override void Enter()
        {
            // TODO : 아이템 설정

            Console.Clear();
            Console.WriteLine("상점에 들어갑니다...");
            Thread.Sleep(2000);
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            // TODO : 상점 입력
            Console.Clear();                     
            game.Player.ShowInfo();
            Console.WriteLine("구입할 상품 번호를 입력해 주세요.");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");
            Render();
        }

        public override void Render()
        {
            // TODO : 상점 상황 출력
            Console.WriteLine("상점 품목");
            for (int i = 0; i < itemslist.Count; i++)
            {
                Item item = itemslist[i];
                Console.WriteLine($"{i + 1}. {item.Name} : {item.Description} " );
                Console.WriteLine($"가격 {item.Price}G");
            }
        }

        public override void Update()
        {
            string input = Console.ReadLine();
            int ch;
            int.TryParse(input, out ch);
            // TODO : 상점 처리
            Console.Clear();                      
            if (ch == 0)
            {
                game.ReturnScene();
            }
            Item pickitem = itemslist[ch - 1];
            if (pickitem.Price > game.Player.Gold)
            {
                Console.WriteLine($"소지금이 부족합니다.");
            }
            else
            {
                game.Player.Gold -= pickitem.Price;
                Console.WriteLine($"{pickitem.Name}을 구매하여 소지금이 {game.Player.Gold}G가 되었습니다");
                if (pickitem.Name == "총")
                {
                    game.Player.Attack += 3;
                    Console.WriteLine($"{pickitem.Name}을 구입하여 공격이 3 상승했습니다");
                }
                else if (pickitem.Name == "방탄 조끼")
                {
                    game.Player.Defense += 2;
                    Console.WriteLine($"{pickitem.Name}을 구입하여 방어가 2 상승했습니다");
                }
            }
            game.Player.ShowInfo();
            Thread.Sleep(2000);
        }
    }
}
