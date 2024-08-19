using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes.Events
{
    //이벤트명 ReinforcedItem
    internal class ReinforcedItemEvent : Scene
    {
        private string input;


        public ReinforcedItemEvent(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("공장지역을 지나가던 당신은 아직 기동되는 기계를 발견했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("기계가 큰소리를 내며 완제품을 내뱉더니 기동을 정지했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"당신은 갓 만들어진 강화 슈트를 발견했습니다.");
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
            
            game.Player.Trace += 1;
            game.Player.Defense += 10;
            game.Player.ShowInfo();
            Console.WriteLine("당신은 아이템을 습득하였습니다.");
            // 아이템 습득 표현 해줘야 함
            Console.WriteLine($" 아이템 강화슈트 습득");
            Console.WriteLine("전신을 보호하는 갑옷이다. 소지시 방어 +10");
            Console.WriteLine("전진하려면 아무런 키를 눌러주세요.");
        }

        public override void Update()
        {
            //연결할 씬 입력
            game.ChangeScene(SceneType.FactoryAreaBattle);
        }
    }
}

