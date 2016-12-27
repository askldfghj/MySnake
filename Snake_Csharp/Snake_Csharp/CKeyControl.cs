using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    class CKeyControl : CModule
    {
        ConsoleKeyInfo mPressKey;
        
        Datas d;
        public override void Init()
        {
            d = Datas.GetInstance;
        }
        public override void Update()
        {
            KeyPress();
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        public void AbleArrowKey(Datas.Direction dir)
        {
            if (dir == d.mDoNotDirection)
            {
                return;
            }
            else 
            {
                d.mCurrentDirection = dir;
                switch (dir)
                {
                    case Datas.Direction.Left:
                        d.mDoNotDirection = Datas.Direction.Right;
                        break;
                    case Datas.Direction.Right:
                        d.mDoNotDirection = Datas.Direction.Left;
                        break;
                    case Datas.Direction.Up:
                        d.mDoNotDirection = Datas.Direction.Down;
                        break;
                    case Datas.Direction.Down:
                        d.mDoNotDirection = Datas.Direction.Up;
                        break;
                }
            }
        }
        private void KeyPress()
        {
            if (Console.KeyAvailable == true)
            {
                mPressKey = Console.ReadKey(true);
                switch (mPressKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        AbleArrowKey(Datas.Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        AbleArrowKey(Datas.Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        AbleArrowKey(Datas.Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        AbleArrowKey(Datas.Direction.Down);
                        break;
                    default:
                        d.mPressed = false;
                        break;
                }
            }
        }
    }
}
