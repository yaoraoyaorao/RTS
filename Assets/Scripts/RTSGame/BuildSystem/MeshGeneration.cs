/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：MeshGeneration
 // 创建日期：2022/3/10 21:56:09
 // 功能描述：网格系统生成
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class MeshGeneration
    {
        private Grid<CellObject> grid;
        private int width;
        private int height;
        private int cellSize;

        //网格
        public Grid<CellObject> Grid { get => grid; set => grid = value; }
        //网格宽
        public int Width { get => width; set => width = value; }
        //网格大小
        public int Height { get => height; set => height = value; }
        //单元格大小
        public int CellSize { get => cellSize; set => cellSize = value; }

        public MeshGeneration(int w,int h,int c)
        {
            this.width = w;
            this.height = h;
            this.cellSize = c;
            Grid = new Grid<CellObject>(Width, Height, CellSize, (Grid<CellObject> g, int x, int y) => new CellObject(g, x, y), true);
        }

    }
}

