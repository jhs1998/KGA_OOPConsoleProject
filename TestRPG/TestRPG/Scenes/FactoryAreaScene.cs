using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes
{
    internal class FactoryAreaScene : Scene
    {
        private string input;


        public FactoryAreaScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            game.Player.ShowInfo();
            Console.WriteLine("당신은 공장 지역으로 진입했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("한때 이곳은 도시가 개발되며 호황을 맞이했지만 지금은 그저 조직의 군수물자를 생산할 뿐입니다.");
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
            //가야할 위치
            game.ChangeScene(SceneType.FactoryAreaBattle);
        }
    }

}

