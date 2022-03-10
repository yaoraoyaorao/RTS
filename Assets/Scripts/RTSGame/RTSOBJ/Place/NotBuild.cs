/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：NotBuild
 // 创建日期：2022/3/10 7:59:28
 // 功能描述：不可建筑的类型
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class NotBuild : IPlace
    {
        public NotBuild(int id, string name, string info, E_PlaceType placeType = E_PlaceType.NotBuildable) : base(id, name, info, placeType) { }

        private List<BuildRes> buildResList;

        public List<BuildRes> BuildResList { get => buildResList; set => buildResList = value; }
    }
}

