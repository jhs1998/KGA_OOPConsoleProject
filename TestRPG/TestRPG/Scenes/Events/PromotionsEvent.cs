using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes.Events
{
    // 이벤트명 Promotions
    internal class PromotionsEvent : Scene
    {
        private string input;


        public PromotionsEvent(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("당신은 길을 걷다 시끄러운 소리에 고개를 위로 올렸습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("하늘에서 드론이 당신을 향해 빠른 속도로 다가왔습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("\"럭키가이를 만났군요! 기업 프로모션 입니다! 당신을 강화시켜 드릴께요!\"");
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
            Console.WriteLine("당신은 몸이 더 강해진것을 느꼈습니다.");
            Thread.Sleep(1000);
            Console.WriteLine($" 체력 상승 : {game.Player.MaxHP} + 100, 이성 상승{game.Player.MaxMP} + 20");
            Thread.Sleep(1000);
            Console.WriteLine("전진하려면 아무런 키를 눌러주세요.");
            // MAX체력 상승 현재 체력 상승, 이성 또한
            game.Player.MaxHP += 100;
            game.Player.PluseCurHP(100);
            game.Player.MaxMP += 20;
            game.Player.PluseCurMP(20);
            game.Player.ShowInfo();
        }

        public override void Update()
        {
            //연결할 씬 입력
            game.ChangeScene(SceneType.MainStreetBattle);
        }
    }
}

