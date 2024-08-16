using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.Players;

namespace TestRPG.Scenes.NewFolder
{
    public class BattleResurtScene : Scene
    {
        private Monster monster;
        public BattleResurtScene(Game game) : base(game)
        {
        }
        public void GetMonster(Monster monster)
        {
            this.monster = monster;
        }

        public override void Enter()
        {
            Console.Clear();
            if (monster != null)
            {
                // TODO : 전투 결과 출현
                Console.WriteLine($"{monster.Name}{game.Player.Trace}을 격파 ");
            }
            else
                Console.WriteLine("몬스터의 정보가 안들어옴");
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
            // TODO : 전투 상황 출력           
            Console.Clear();
            
            Console.WriteLine($"몬스터에게 {monster.Mongold} G 획득");
            game.Player.Plusegold(monster.Mongold);
            game.Player.Trace += 1;
            game.Player.ShowInfo();
            Thread.Sleep(3000);
            Console.WriteLine("아무런 키나 입력하세요....");
        }

        public override void Update()
        {
            // TODO : 전투 진행
            if (game.Player.Area == 0)
            {
                if (game.Player.Trace <= 3)
                {
                    game.ChangeScene(SceneType.Battle);
                }
                else if (game.Player.Trace == 4)
                    game.ChangeScene(SceneType.CrossRoad);
            }
            else if (game.Player.Area == 1)
            {
                if (game.Player.Trace <= 7)
                    game.ChangeScene(SceneType.MainStreetBattle);
                else if (game.Player.Trace == 8)
                    game.ChangeScene(SceneType.Marmotte);
                else if (game.Player.Trace <= 10)
                    game.ChangeScene(SceneType.MainStreetBattle);
                else if (game.Player.Trace == 11)
                    game.ChangeScene(SceneType.Town);
                else if (game.Player.Trace <= 13)
                    game.ChangeScene(SceneType.MainStreetBattle);
                else if (game.Player.Trace == 14)
                    game.ChangeScene(SceneType.Promotions);
                else if (game.Player.Trace <= 16)
                    game.ChangeScene(SceneType.MainStreetBattle);
                else if (game.Player.Trace == 17)
                    game.ChangeScene(SceneType.Town);
            }
            else if (game.Player.Area == 2)
            {
                if (game.Player.Trace <= 7)
                    game.ChangeScene(SceneType.FactoryAreaBattle);
                else if (game.Player.Trace == 8)
                    game.ChangeScene(SceneType.Runpeople);
                else if (game.Player.Trace <= 10)
                    game.ChangeScene(SceneType.FactoryAreaBattle);
                else if (game.Player.Trace == 11)
                    game.ChangeScene(SceneType.Town);
                else if (game.Player.Trace <= 13)
                    game.ChangeScene(SceneType.FactoryAreaBattle);
                else if (game.Player.Trace == 14)
                    game.ChangeScene(SceneType.ReinforcedItem);
                else if (game.Player.Trace <= 16)
                    game.ChangeScene(SceneType.FactoryAreaBattle);
                else if (game.Player.Trace == 17)
                    game.ChangeScene(SceneType.Town);
            }
        }
    }
}
