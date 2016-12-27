using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    //싱글턴 패턴 클래스
    class Datas
    {
        static Datas instance;
        public bool mPressed;
        public bool mIsGameOver;

        public List<CBlock> mBlockList;

        //형식 한정
        public const int MAX_RIGHT = 10;
        public const int MAX_BOTTOM = 10;
        public enum GamePhase {MainScreen, RunSnake, Finish}
        public GamePhase mCurrentPhase { set; get; }
        public enum Direction { Left, Right, Down, Up}
        public Direction mCurrentDirection { set; get; }
        public Direction mDoNotDirection { set; get; }
        public enum Position { Head, Food, Body, Dummy }

        Datas()
        {
            mCurrentPhase = GamePhase.MainScreen;
            mCurrentDirection = Direction.Right;
            mDoNotDirection = Direction.Left;
            mPressed = false;
            mIsGameOver = false;
            mBlockList = new List<CBlock>();
        }
        public static Datas GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Datas();
                }

                return instance;
            }
        }
    }
}
