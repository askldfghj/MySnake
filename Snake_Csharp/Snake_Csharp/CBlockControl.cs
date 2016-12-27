using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Csharp
{
    class CBlockControl : CModule
    {
        Datas d;
        public override void Init()
        {
            d = Datas.GetInstance;
            CHeadBlock head = new CHeadBlock();
            CDummyBlock dummy = new CDummyBlock();
            CFoodBlock food = new CFoodBlock();
            head.Init();
            dummy.Init(head);
            food.Init();
            d.mBlockList.Add(head);
            d.mBlockList.Add(dummy);
            d.mBlockList.Add(food);
        }
        public override void Update()
        {
            for (int i = d.mBlockList.Count - 1; i >= 0; i--)
            {
                d.mBlockList[i].Update();
            }
            IsCrash();
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        public void IsCrash()
        {
            int x;
            int y;
            Datas.Position posi;
            x = d.mBlockList[0].X;
            y = d.mBlockList[0].Y;
            if (x < 1 || y < 1 || x > Datas.MAX_RIGHT-2 || y > Datas.MAX_BOTTOM-2)
            {
                d.mIsGameOver = true;
                return;
            }
            for (int i = 1; i < d.mBlockList.Count; i++)
            {
                if (x == d.mBlockList[i].X && y == d.mBlockList[i].Y)
                {
                    posi = d.mBlockList[i].GetPosition();
                    switch (posi)
                    {
                        case Datas.Position.Body:
                            d.mIsGameOver = true;
                            break;
                        case Datas.Position.Food:
                            CBodyBlock newbody = new CBodyBlock();
                            newbody.Init(d.mBlockList[d.mBlockList.Count - 3], d.mBlockList[d.mBlockList.Count - 2]);
                            CFoodBlock newfood = new CFoodBlock();
                            newfood.Init();
                            CDummyBlock newdummy = new CDummyBlock();
                            newdummy.Init(newbody);
                            for (int j = 0; j < 2; j++)
                            {
                                d.mBlockList.RemoveAt(d.mBlockList.Count - 1);
                            }
                            d.mBlockList.Add(newbody);
                            d.mBlockList.Add(newdummy);
                            d.mBlockList.Add(newfood);
                            break;
                    }
                }
                if (d.mIsGameOver)
                    break;
            }
        }
    }
}
