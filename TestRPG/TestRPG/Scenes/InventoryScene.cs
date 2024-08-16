using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG.Scenes
{
    public class InventoryScene : Scene
    {

        public InventoryScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            // TODO : 인벤토리 설정

            Console.Clear();
            Console.WriteLine("인벤토리를 엽니다...");
            Thread.Sleep(1000);
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            // TODO : 인벤토리 입력
            Console.Clear();
            game.Player.ShowInfo();
            Render();
            Console.WriteLine("\n사용할 아이템을 골라주세요.");
            Console.WriteLine("0. 돌아가기");
           
        }

        public override void Render()
        {
            // TODO : 인벤토리 상황 출력
            Console.WriteLine("인벤토리");
            if (game.Player.Inventory.Count == 0)
            {
                Console.WriteLine("비어있습니다.");
            }
            else
            {
                for (int i = 0; i < game.Player.Inventory.Count; i++)
                {
                    Item item = game.Player.Inventory[i];
                    Console.WriteLine($"{i + 1}번 {item.Name} : {item.Description}");
                }
            }
        }

        public override void Update()
        {
            // TODO : 인벤토리 처리
            string input = Console.ReadLine();
            int ch;
            int.TryParse(input, out ch);           
            Console.Clear();
            if (ch == 0)
            {
                game.ReturnScene();
            }
            else if (ch > 0 && ch < game.Player.Inventory.Count)
            {
                Item item = game.Player.Inventory[ch - 1];

                if (item.UsePasible == true)
                {
                    Console.WriteLine($"{item.Name}을 사용하시겠습니까? (Y/N)");
                    string iteminput = Console.ReadLine();
                    if (iteminput == "y" || iteminput == "Y")
                    {
                        item.Use(game.Player, game.Player.Monster);
                        game.Player.Inventory.Remove(item);
                        Console.WriteLine($"{item.Name}를 사용하여 인벤토리에서 삭제 되었습니다.");
                    }
                }
                else
                {
                    Console.WriteLine($"{item.Name}은 장착템이라 사용 불가능합니다.");
                }
            }
            else
                Console.WriteLine("잘못 입력하셨습니다.");
            
            game.Player.ShowInfo();
            Thread.Sleep(2000);
        }
    }
}
