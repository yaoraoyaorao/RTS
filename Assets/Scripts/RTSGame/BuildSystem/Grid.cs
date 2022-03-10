/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：Grid
 // 创建日期：2022/3/10 21:15:39
 // 功能描述：网格对象
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Grid<T>
    {
        private int width;
        private int height;
        private int cellSize;

        private T[,] gridArray;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int CellSize { get => cellSize; set => cellSize = value; }

        public Grid(int width,int height,int cellSize,Func<Grid<T>,int,int,T> createGridObject,bool showDebug)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.gridArray = new T[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    gridArray[x,z] = createGridObject(this, x, z);
                }
            }

            if (showDebug)
            {

                for (int x = 0; x < gridArray.GetLength(0); x++)
                {
                    for (int z = 0; z < gridArray.GetLength(1); z++)
                    {
                        Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.black, 100f);
                        Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.black, 100f);
                    }
                }
                Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
                Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
            }
        }

        //获取网格坐标位置
        public void GetXZ(Vector3 worldPos,out int x,out int z)
        {
            x = Mathf.FloorToInt(worldPos.x / cellSize);
            z = Mathf.FloorToInt(worldPos.z / cellSize);
        }

        //获取世界坐标位置
        public Vector3 GetWorldPosition(int x,int z)
        {
            return new Vector3(x, 0, z) * cellSize;
        }

        /// <summary>
        /// 通过网格坐标获取网格对象
        /// </summary>
        /// <returns></returns>
        public T GetObject(int x,int z)
        {
            if (x >= 0 && z >= 0 && x < width && z < height) 
            {
                return gridArray[x, z];
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 通过世界坐标获取对象
        /// </summary>
        /// <param name="worldPos"></param>
        /// <returns></returns>
        public T GetObject(Vector3 worldPos)
        {

            GetXZ(worldPos, out int x, out int z);
            return GetObject(x, z);
        }

        /// <summary>
        /// 通过网格坐标修改值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name="value"></param>
        public void SetObject(int x,int z,T value)
        {
            if (x >= 0 && z >= 0 && x < width && z < height) 
            {
                gridArray[x, z] = value;
            }
        }

        /// <summary>
        /// 通过世界坐标修改值
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="value"></param>
        public void SetObject(Vector3 worldPos,T value)
        {
            GetXZ(worldPos, out int x, out int z);
            gridArray[x, z] = value;
        }

    }
}

