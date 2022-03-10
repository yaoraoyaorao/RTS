/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：CellObject
 // 创建日期：2022/3/10 21:34:26
 // 功能描述：单元格对象
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class CellObject
    {
        private int x;
        private int y;
        private Grid<CellObject> grid;
        private bool canWalk;
        private RTSOBJ obj;


        private float gCost;
        private float hCost;
        private float fCost;
        private CellObject cameFromNode;

        public CellObject(Grid<CellObject> grid)
        {
            this.grid = grid;
        }

        public CellObject(Grid<CellObject> grid,int x,int y,bool canWalk = true)
        {
            this.X = x;
            this.Y = y;
            this.grid = grid;
            this.CanWalk = canWalk;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool CanWalk { get => canWalk; set => canWalk = value; }
        public RTSOBJ Obj { get => obj; set => obj = value; }
        public float GCost { get => gCost; set => gCost = value; }
        public float HCost { get => hCost; set => hCost = value; }
        public float FCost { get => fCost; set => fCost = value; }
        public CellObject CameFromNode { get => cameFromNode; set => cameFromNode = value; }

        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="obj"></param>
        public void SetObject(RTSOBJ obj)
        {
            this.obj = obj;
        }

        /// <summary>
        /// 清除对象
        /// </summary>
        public void ClearObject()
        {
            this.obj = null;
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            return this.obj == null;
        }

        public override string ToString()
        {
            return "x:" + x + ",y:" + y;
        }
    }

}
