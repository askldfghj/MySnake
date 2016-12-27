using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake_Csharp
{
    class CDraw : CModule
    {
        Datas d;
        public override void Init()
        {
            d = Datas.GetInstance;
            DrawMap();
            for (int i = 0; i < d.mBlockList.Count; i++)
            {
                Drawblock(d.mBlockList[i].X, d.mBlockList[i].Y, d.mBlockList[i].GetShape());
            }
        }
        public override void Update()
        {
            switch (d.mCurrentPhase)
            {
                case Datas.GamePhase.MainScreen:
                    break;
                case Datas.GamePhase.RunSnake:
                    Drawing();
                    break;
                case Datas.GamePhase.Finish:
                    break;
            }
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        private void DrawMap()
        {
            for (int i = 0; i < Datas.MAX_RIGHT; i++)
            {
                for (int j = 0; j < Datas.MAX_BOTTOM; j++)
                {
                    if (i == 0 || i == Datas.MAX_RIGHT - 1)
                    {
                        Console.Write("□");
                        continue;
                    }
                    else if (j == 0 || j == Datas.MAX_BOTTOM - 1)
                    {
                        Console.Write("□");
                        continue;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        void Drawblock(int x, int y, String shape)
        {
            try
            {
                Console.SetCursorPosition(x * 2, y);
                Console.Write(shape);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        void Drawing()
        {
            if (!d.mIsGameOver)
            {
                for (int i = 0; i < d.mBlockList.Count; i++)
                {
                    Drawblock(d.mBlockList[i].X, d.mBlockList[i].Y, d.mBlockList[i].GetShape());
                }
            }
        }
    }
}
