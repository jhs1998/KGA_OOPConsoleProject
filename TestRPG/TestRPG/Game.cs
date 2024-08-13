using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using TestRPG.Scenes;

namespace TestRPG
{
    public class Game
    {
        private bool isRunning; // 게임 동작 여부

        private Scene[] scenes;
        private Scene curScene;
        public Scene CurScene { get { return curScene; } }

        private Player player;
        public Player Player { get { return player; } set { player = value; } }

        public void Run()
        {
            Start(); // 준비작업
            while (isRunning) // ㄱㅖ속해서 플레이
            {
                Render(); //표현 : 게임데이터를 이용해 콘솔 출력
                Input();  //입력 : 키보드를 통해 입력받기
                Update(); //처리 : 받은 입력을 토대로 게임데이터를 가공
            }
            End(); // 마무리작업
        }

        public void ChangeScene(SceneType sceneType) //씬 바꾸기
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();  
        }

        public void Over()
        {
            isRunning = false; // 게임 종료
        }

        private void Start() // 씬 생성
        {
            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this);
            scenes[(int)SceneType.Town] = new TownScene(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.Inventory] = new InventoryScene(this);
            scenes[(int)SceneType.Shop] = new ShopScene(this);
            scenes[(int)SceneType.Event] = new ShopScene(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }
    }
}
