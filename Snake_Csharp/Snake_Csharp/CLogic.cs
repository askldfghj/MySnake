using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    class CLogic : CModule
    {
        Datas d;
        CKeyControl key;
        CBlockControl bloc;
        CDraw draw;
        List<CModule> list;

        bool GameExit;

        public override void Init()
        {
            d = Datas.GetInstance;
            key = new CKeyControl();
            bloc = new CBlockControl();
            draw = new CDraw();
            list = new List<CModule>();
            list.Add(key);
            list.Add(bloc);
            list.Add(draw);
            GameExit = false;

            d.mCurrentPhase = Datas.GamePhase.RunSnake;
        }
        public override void Update()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Update();
            }
        }
        public override void Destroy()
        {
            for (int i = list.Count-1; i >= 0; i--)
            {
                list[i].Destroy();
            }
        }

        public void RunProgram()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Init();
            }
            while (!d.mIsGameOver)
            {
                Update();
                System.Threading.Thread.Sleep(150);
            }
        }

        public void SnakeReady()
        {
            
        }
    }
}
