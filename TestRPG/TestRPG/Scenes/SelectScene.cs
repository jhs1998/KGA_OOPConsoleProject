using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.NewFolder;
using TestRPG.Players;

namespace TestRPG.Scenes
{
    public class SelectScene : Scene
    {
        public enum State { Name, Job, Confirm }
        private State curState;

        private string input;
        private string nameInput;
        protected List<PlayerSkill> skills = new List<PlayerSkill>();

        public SelectScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            curState = State.Name;
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
            if (curState == State.Name)
            {
                Console.Write("캐릭터의 이름을 입력하세요 : ");
            }
            else if (curState == State.Job)
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 방랑자 ");
                Console.WriteLine("2. 갱단원 ");
                Console.WriteLine("3. 기업인 ");
                Console.Write("직업을 선택하세요 : ");
            }
            else if (curState == State.Confirm)
            {
                Console.WriteLine("===================");
                Console.WriteLine($"이름 : {game.Player.Name}");
                if (game.Player.Job == Job.Nomad)
                    Console.WriteLine("직업 : 방랑자");
                else if (game.Player.Job == Job.StreetKid)
                    Console.WriteLine("직업 : 갱단원");
                else if (game.Player.Job == Job.CorporateSlaves)
                    Console.WriteLine("직업 : 기업인");             
                Console.WriteLine($"체력 : {game.Player.MaxHP}");
                Console.WriteLine($"이성 : {game.Player.MaxMP}");
                Console.WriteLine($"공격 : {game.Player.Attack}");
                Console.WriteLine($"내구 : {game.Player.Defense}");
                Console.WriteLine($"회피 : {game.Player.Avoidance}");
                if (game.Player.Job == Job.Nomad)                
                    Console.WriteLine("스킬 : 훔치기");                                      
                else if (game.Player.Job == Job.StreetKid)
                    Console.WriteLine("스킬 : 마구베기");
                else if (game.Player.Job == Job.CorporateSlaves)
                    Console.WriteLine("스킬 : 급속재생");
                Console.WriteLine($"소지금 : {game.Player.Gold}");               
                Console.WriteLine("===================");
                Console.WriteLine();
                if (game.Player.Job == Job.Nomad)
                {
                    Console.WriteLine("당신은 거친 황야를 떠돌다가 이 도시에 도착했습니다.");
                    Console.WriteLine("쌓인 피로를 풀겸 들어간 여관에서 한 무리의 양아치와 시비가 붙어");
                    Console.WriteLine("양아치가 속했던 조직이 당신을 노립니다.");
                    Console.WriteLine("원한관계를 잊지않는 당신은 조직의 보스를 만나고자 합니다.");
                }
                else if (game.Player.Job == Job.StreetKid)
                {
                    Console.WriteLine("당신은 도시의 길거리에서 태어난 아이였습니다.");
                    Console.WriteLine("다른 아이들 보다 운이 좋아 무사히 청년이 된 당신은");
                    Console.WriteLine("몇 남지 않은 친구가 조직의 보스에게 죽었다는 말을 들었습니다.");
                    Console.WriteLine("친구의 원한을 갚기위해 당신은 도시의 뒷골목을 휘어잡은 보스를 만나러 갑니다.");
                }
                else if (game.Player.Job == Job.CorporateSlaves)
                {
                    Console.WriteLine("당신은 도시에서 가장 높은 마천루에 속한 사람입니다.");
                    Console.WriteLine("더 높은 곳에 오르기 위해 나아가던 와중 기회가 찾아왔습니다.");
                    Console.WriteLine("조직의 보스가 훔쳐간 기업의 물건을 찾아오라는 상사의 말을 따라 ");
                    Console.WriteLine("당신은 기업의 물건을 훔쳐간 보스를 찾기위해 도시의 어둠으로 나아갑니다.");
                }
                Console.WriteLine();
                Console.WriteLine("이대로 플레이 하시겠습니까?(y/n)");
            }
        }

        public override void Update()
        {
            if (curState == State.Name)
            {
                if (input == string.Empty)
                    return;

                nameInput = input;
                curState = State.Job;
            }
            else if (curState == State.Job)
            {
                if (Job.TryParse(input, out Job select) == false)
                    return;

                if (Enum.IsDefined(typeof(Job), select) == false)
                    return;

                switch (select)
                {
                    case Job.Nomad:
                        game.Player = new Nomad(nameInput);
                        break;
                    case Job.StreetKid:
                        game.Player = new StreetKid(nameInput);
                        break;
                    case Job.CorporateSlaves:
                        game.Player = new CorporateSlaves(nameInput);
                        break;
                }

                curState = State.Confirm;
            }
            else if (curState == State.Confirm)
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                        game.ChangeScene(SceneType.Town);
                        break;
                    case "N":
                    case "n":
                        curState = State.Name;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
