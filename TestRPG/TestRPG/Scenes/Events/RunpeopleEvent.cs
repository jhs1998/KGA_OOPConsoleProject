using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes.Events
{
    // 이벤트명 Runpeople
    internal class RunpeopleEvent : Scene
    {
        private string input;


        public RunpeopleEvent(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("길을 걷던 와중 누군가가 당신과 부딛치며 넘어졌습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("정신을 차리고 따지려 들었지만 상대는 어느샌가 저멀리 달아났습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("상대가 넘어진 자리를 보니 아이템이 떨어져 있군요.");
            Thread.Sleep(3000);
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
            Console.Clear();
            game.Player.ShowInfo();
            game.Player.Trace += 1;
            Console.WriteLine("당신은 아이템을 습득하였습니다.");
            // 아이템 습득 표현 해줘야 함
            Console.WriteLine($" 아이템 뭐뭐 습득");
            Console.WriteLine("아이템 설명");
            Console.WriteLine("전진하려면 아무런 키를 눌러주세요.");
        }

        public override void Update()
        {
            //연결할 씬 입력
            game.ChangeScene(SceneType.FactoryAreaBattle);
        }
    }

}

