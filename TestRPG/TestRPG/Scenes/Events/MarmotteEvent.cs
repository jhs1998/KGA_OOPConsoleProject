using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TestRPG.Scenes.SelectScene;

namespace TestRPG.Scenes.Events
{
    // 이벤트명 Marmotte
    internal class MarmotteEvent : Scene
    {
        private string input;
        Random rand = new Random();
        public int random;

        public MarmotteEvent(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("갑자기 당신을 부르는 소리에 소리가 들리는 방향을 봅니다.");
            Thread.Sleep(1000);
            Console.WriteLine("\"이봐 건실한 청년! 자네 내 연구를 도와줄 생각이 있나?\"");
            Thread.Sleep(1000);
            Console.WriteLine("의심스러운 박사가 당신에게 도움을 청합니다.");
            Thread.Sleep(1000);
            Console.WriteLine("실험의 참여여부는 당신에게 달린듯 합니다.");
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
            game.Player.Trace += 1;
            Console.WriteLine("실험에 참여 하시겠습니까?(y/n)");
            // MAX체력 상승 현재 체력 상승, 이성 또한
            Thread.Sleep(2000);
        }

        public override void Update()
        {
            Console.Clear();
            game.Player.ShowInfo();
            switch (input)
            {
                case "Y":
                case "y":
                    random = rand.Next(0, 10);
                    if (random >= 5)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\"역시 나는 천재야!\"");
                        Thread.Sleep(1000);
                        Console.WriteLine("신체가 달라진것이 느껴진다");
                        Thread.Sleep(1000);
                        Console.WriteLine("실험에 성공하였다!");
                        Thread.Sleep(1000);
                        Console.WriteLine($" 체력 상승 : {game.Player.MaxHP} + 300, 이성 상승{game.Player.MaxMP} + 50");
                        Console.WriteLine($" 내구 상승 : {game.Player.Defense} + 10, 파워 상승{game.Player.Attack} + 10");
                        game.Player.MaxHP += 300;
                        game.Player.PluseCurHP(300);
                        game.Player.MaxMP += 50;
                        game.Player.PluseCurMP(50);
                        game.Player.Defense += 10;
                        game.Player.PluseAttack(10);
                        game.Player.ShowInfo();
                        Thread.Sleep(4000);
                        //다음지역으로
                        game.ChangeScene(SceneType.MainStreetBattle);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("눈을 뜨니 박사는 사라져 있었다....");
                        Thread.Sleep(1000);
                        Console.WriteLine("실험은 실패 한듯 하다.");
                        Thread.Sleep(1000);
                        Console.WriteLine($" 체력 하락 : {game.Player.MaxHP} - 200, 이성 하락{game.Player.MaxMP} - 20");
                        Console.WriteLine($" 내구 하락 : {game.Player.Defense} - 5, 파워 하락{game.Player.Attack} - 2");
                        game.Player.MaxHP -= 200;
                        if (game.Player.MaxHP < game.Player.CurHP)
                            game.Player.equalCurHP(game.Player.MaxHP);
                        game.Player.MaxMP -= 20;
                        if (game.Player.MaxMP < game.Player.CurMP)
                            game.Player.equalCurMP(game.Player.MaxMP);
                        game.Player.Defense -= 5;
                        game.Player.Attack -= 2;
                        game.Player.ShowInfo();
                        Thread.Sleep(4000);
                        //다음지역으로
                        game.ChangeScene(SceneType.MainStreetBattle);
                        break;
                    }
                case "N":
                case "n":
                    Console.WriteLine("당신은 말을거는 박사를 무시하고 앞으로 나아갔다.");
                    //다음지역으로
                    game.ChangeScene(SceneType.MainStreetBattle);
                    break;
                default:
                    break;
            }
        }
    }
}

