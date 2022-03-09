/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IPlace
 // 创建日期：2022/3/9 17:06:05
 // 功能描述：放置类型   继承RTSOBJ
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class IPlace : RTSOBJ
    {
        public IPlace(int id, string name,string info, E_PlaceType placeType, E_RTSType type = E_RTSType.Place):base(id,name,info, type)
        {
            PlaceType = placeType;
        }

        /// <summary>
        /// 物体在网格中所占尺寸
        /// </summary>
        private Vector2Int size;

        /// <summary>
        /// 物体在网格中所占位置
        /// </summary>
        private Vector2Int position;

        private E_PlaceType placeType;

        public Vector2Int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Vector2Int Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        public E_PlaceType PlaceType { get => placeType; set => placeType = value; }

    }

}
