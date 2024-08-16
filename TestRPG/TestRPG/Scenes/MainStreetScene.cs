using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes
{
    internal class MainStreetScene : Scene
    {
        private string input;


        public MainStreetScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            game.Player.ShowInfo();
            Console.WriteLine("당신은 도시의 중심인 번화가로 들어갔습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("사회적으로 부유한 이들이 모이는 이곳에는 어느 순간부터 무거운 공기가 감돌기 시작했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("당신은 이곳에서 보스의 흔적을 찾으려 합니다.");
            Thread.Sleep(2000);
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            Console.ReadKey();
        }

        public override void Render()
        {
            
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.MainStreetBattle);          
        }
    }

}

