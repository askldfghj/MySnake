using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    abstract class CBlock : CModule
    {
        public Datas d;
        public int X { set; get; }
        public int Y { set; get; }
        protected String Shape;

        
        protected Datas.Position Posi;


        public override void Init()
        {
            d = Datas.GetInstance;
            X = 0;
            Y = 0;
            Shape = null;
        }

        public String GetShape()
        {
            return Shape;
        }

        public Datas.Position GetPosition()
        {
            return Posi;
        }

        public abstract void Move();
    }

    class CHeadBlock : CBlock
    {
        public override void Init()
        {
            d = Datas.GetInstance;
            X = Datas.MAX_RIGHT/2;
            Y = Datas.MAX_BOTTOM/2;
            Shape = "■";
            Posi = Datas.Position.Head;
        }
        public override void Update()
        {
            Move();
        }
        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Move()
        {
            switch (d.mCurrentDirection)
            {
                case Datas.Direction.Left:
                    X--;
                    break;
                case Datas.Direction.Right:
                    X++;
                    break;
                case Datas.Direction.Up:
                    Y--;
                    break;
                case Datas.Direction.Down:
                    Y++;
                    break;
            }
        }
    }
    class CBodyBlock : CBlock
    {
        CBlock FrontBlock;

        public void Init(CBlock f, CBlock dummy)
        {
            d = Datas.GetInstance;
            SetFront(f);
            SetCurrent(dummy);
            Shape = "■";
            Posi = Datas.Position.Body;
        }
        public override void Update()
        {
            Move();
        }
        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Move()
        {
            this.X = FrontBlock.X;
            this.Y = FrontBlock.Y;
        }

        void SetFront (CBlock f)
        {
            FrontBlock = f;
        }
        void SetCurrent (CBlock dummy)
        {
            this.X = dummy.X;
            this.Y = dummy.Y;
        }
    }
    class CDummyBlock : CBlock
    {
        CBlock FrontBlock;

        public void Init(CBlock f)
        {
            d = Datas.GetInstance;
            X = 0;
            Y = Datas.MAX_RIGHT+1;
            Shape = "  ";
            SetFront(f);
            Posi = Datas.Position.Dummy;
        }
        public override void Update()
        {
            Move();
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        void SetFront(CBlock f)
        {
            FrontBlock = f;
        }

        public override void Move()
        {
            this.X = FrontBlock.X;
            this.Y = FrontBlock.Y;
        }
    }
    class CFoodBlock : CBlock
    {
        Random randX;
        Random randY;
        Random randSeed;
        bool RandomOk;
        public override void Init()
        {
            d = Datas.GetInstance;
            Shape = "●";
            Posi = Datas.Position.Food;
            randSeed = new Random();
            randX = new Random();
            randY = new Random(randSeed.Next());
            RandomOk = false;
            RandomPosi();
        }
        public override void Update()
        {
            
        }
        public override void Destroy()
        {
            base.Destroy();
        }

        void RandomPosi()
        {
            while (!RandomOk)
            {
                X = randX.Next(1, Datas.MAX_RIGHT-1);
                Y = randY.Next(1, Datas.MAX_BOTTOM-1);
                RandomOk = CheckXY();
            }
        }

        bool CheckXY()
        {
            for (int i = 0; i < d.mBlockList.Count; i++)
            {
                if (X == d.mBlockList[i].X && Y == d.mBlockList[i].Y)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
