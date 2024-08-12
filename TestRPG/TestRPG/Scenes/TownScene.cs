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
            Console.WriteLine("마을로 진입합니다...");
            Thread.Sleep(2000);
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
            Console.WriteLine("마을이다.");
            Console.WriteLine("어디로 이동하겠습니까?");
            Console.WriteLine("1. 전투");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.Write("선택 : ");
        }

        public override void Update()
        {
            switch (input)
            {
                case "1":
                    game.ChangeScene(SceneType.Battle);
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
