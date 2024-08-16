using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes
{
    public class TownScene : Scene
    {
        private string input;

        public TownScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            if (game.Player.Area == 0 && game.Player.Trace == 0)
            {
                Console.WriteLine("보스를 찾아갈 준비를 해야합니다.");
                Thread.Sleep(1000);
                Console.WriteLine("정비를 하고 앞으로 나아가세요");
                Thread.Sleep(2000);
            }
            else if (game.Player.Area == 1 && game.Player.Trace != 17)
            {
                Console.WriteLine("당신은 보스를 찾던 와중 보급의 필요성을 느꼈습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("마침 그런 당신의 앞에 백화점이 보입니다.");
                Thread.Sleep(2000);
            }
            else if (game.Player.Area == 2 && game.Player.Trace != 17)
            {
                Console.WriteLine("당신은 상품을 빼돌린 노동자를 만났습니다");
                Thread.Sleep(1000);
                Console.WriteLine("노동자는 돈을 위해서라면 당신에게 상품을 파는 행위도 서슴지 않습니다");
                Thread.Sleep(2000);
            }
            else if (game.Player.Trace == 17)
            {
                Console.WriteLine("당신은 마침내 보스의 위치를 찾았습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("마지막 휴식을 취해야합니다.");
                Thread.Sleep(2000);
            }
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            game.Player.ShowInfo();
            Console.WriteLine("선택지를 선택하세요.");
            Console.WriteLine("1. 전진");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.Write("선택 : ");
        }

        public override void Update()
        {
            switch (input)
            {
                case "1":
                    if (game.Player.Area == 0)
                    {
                        game.ChangeScene(SceneType.Battle);
                        break;
                    }
                    else if (game.Player.Area == 1)
                    {
                        game.ChangeScene(SceneType.MainStreetBattle);
                        break;
                    }
                    else if (game.Player.Area == 2)
                    {
                        game.ChangeScene(SceneType.FactoryAreaBattle);
                        break;
                    }
                    else if (game.Player.Trace == 17)
                    {
                        game.ChangeScene(SceneType.BossBattle);
                        break;
                    }
                    else
                        break;
                        
                case "2":
                    game.ChangeScene(SceneType.Inventory);
                    break;
                case "3":
                    game.ChangeScene(SceneType.Shop);
                    break;
            }
        }
    }
}
