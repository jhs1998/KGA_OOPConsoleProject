using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes
{
    internal class CrossRoadScene : Scene
    {
        private string input;
        public int area;

        public CrossRoadScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("보스를 찾기위해 앞으로 나아가던 당신의 앞에 갈림길이 있습니다.");
            Thread.Sleep(3000);
            Console.WriteLine("번화가로 가거나 공장지역으로 가야합니다.");
            Thread.Sleep(3000);
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
            Console.WriteLine("나아갈 방향을 선택하세요");
            Console.WriteLine("1. 번화가");
            Console.WriteLine("2. 공장지역");
            Console.Write("선택 : ");
        }

        public override void Update()
        {
            switch (input)
            {
                case "1":
                    game.Player.Area = 1;
                    Console.WriteLine("당신은 번화가로 진입합니다.");
                    Thread.Sleep(2000);
                    game.ChangeScene(SceneType.MainStreet);
                    break;
                case "2":
                    game.Player.Area = 2;
                    Console.WriteLine("당신은 공장 지역으로 진입합니다.");
                    Thread.Sleep(2000);
                    game.ChangeScene(SceneType.FactoryArea);
                    break;
            }
        }
    }

}

