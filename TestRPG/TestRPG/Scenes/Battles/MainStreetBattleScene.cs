using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;

namespace TestRPG.Scenes.NewFolder
{
    public class MainStreetBattleScene : Scene
    {
        private Monster monster;
        private bool continuebattle = true;
        private bool realat = true;
        Random rand = new Random();
        Random atav = new Random();
        public MainStreetBattleScene(Game game) : base(game)
        {
        }
        public void GetMonster(Monster monster)
        {
            this.monster = monster;
        }
        public override void Enter()
        {
            // TODO : 랜덤 몬스터 출연
            int a = rand.Next(3);

            if (game.Player.Trace == 16)
            {
                monster = new Monster("지부장", 400, 15, 2, 2000, 2, 0, 15, "쌍권총 난사");
            }
            else if (a == 0)
            {
                monster = new Monster("행동대장", 500, 30, 8, 1000, 3, 0, 100, "팔콘펀치");
            }
            else if (a == 1)
            {
                monster = new Monster("정예화 된 조직원", 200, 15, 1, 200, 3, 0, 70, "헤드샷");
            }
            else if (a == 2)
            {
                monster = new Monster("정예화 된 조직원", 200, 20, 4, 300, 2, 0, 50, "강펀치");
            }
            

            Console.Clear();

            Console.WriteLine($"{monster.Name}이/가 나타났다!!!");
            Thread.Sleep(3000);


        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            // TODO : 전투 입력
            Console.Clear();
            game.Player.ShowInfo();
            InterfaceMonster();
            realat = true; // 회패했을때 false가 된것을 다시 때릴수있게 true로 바꿔줌

            Console.WriteLine("\n무엇을 할까?");
            Console.WriteLine("1. 공격");
            foreach (var PlayerSkill in game.Player.skills)
            {
                Console.WriteLine($"2. {PlayerSkill.Name}");
            }
            Console.WriteLine("3. 회피");
            Console.WriteLine("4. 인벤토리");
            Console.Write("선택 : ");
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력

        }

        public override void Update()
        {
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    Console.Clear();
                    AttactMonster();
                    break;
                case "2":
                    Console.Clear();
                    Useskill();
                    break;
                case "3":
                    Console.Clear();
                    AvoidanceAttact();
                    break;
                case "4":
                    game.ChangeScene(SceneType.Inventory);
                    break;
                default:
                    Console.WriteLine("다시 입력해주세요.");
                    break;
            }

            if (monster.HP == 0)
                continuebattle = false;

            if (realat == true)
            {
                if (monster.Skill != monster.Skillcost)
                {
                    if (monster.Name == "지부장")
                    {
                        game.Player.GetDamage(monster.Attack);
                        game.Player.GetDamage(monster.Attack);
                    }
                    else
                        game.Player.GetDamage(monster.Attack);
                    monster.Skill += 1;
                }
                else if (monster.Skill == monster.Skillcost)
                {
                    game.Player.GetSkillDamage(monster.Name, monster.SkillDamage, monster.SkillName);
                    monster.Skill = 0;
                }
            }

            if (continuebattle == false)
            {
                BattleResurtScene battleResurtScene = (BattleResurtScene)game.GetScene(SceneType.BattleResurt);
                battleResurtScene.GetMonster(monster);
                game.ChangeScene(SceneType.BattleResurt);
            }

        }
        private void InterfaceMonster()
        {
            Console.WriteLine($" {monster.Name}");
            Console.WriteLine($"HP : {monster.HP}");
            if (monster.Skill == monster.Skillcost)
                Console.WriteLine($"{monster.Name}이 {monster.SkillName}을/를 준비합니다.");
            Thread.Sleep(1000);
        }
        private void AttactMonster()
        {
            monster.GetDamage(game.Player.Attack);
            Thread.Sleep(1000);
            Console.Clear();
        }
        private void Useskill()
        {
            game.Player.Skill(monster);
            Thread.Sleep(1000);
            Console.Clear();
        }
        private void AvoidanceAttact()
        {
            Console.WriteLine($"{game.Player.Name}이/가 적의 공격을 피하려 합니다.");
            Thread.Sleep(1000);
            int b = atav.Next(11);
            if (b > game.Player.Avoidance)
            {
                Console.WriteLine("적의 공격을 회피하지 못했습니다.");
                Console.WriteLine("");
                Thread.Sleep(1000);

            }
            else
            {
                if (monster.Skillcost == monster.Skill)
                    monster.Skill = 0;
                Console.WriteLine("적의 공격을 회피했습니다.");
                Console.WriteLine("");
                Thread.Sleep(1000);
                realat = false;
            }
        }
    }
}
