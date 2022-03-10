/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：BuildSystem
 // 创建日期：2022/3/10 21:46:11
 // 功能描述：建筑系统
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class BuildSystem
    {
        private List<Build> buildList;
        private Build currentBuild;
        private MeshGeneration grid;


        public List<Build> BuildList { get => buildList; set => buildList = value; }
        public Build CurrentBuild { get => currentBuild; set => currentBuild = value; }

        public void Init(MeshGeneration g,List<Build> buildList)
        {
            this.grid = g;
            this.buildList = buildList;

            if(buildList != null)
                CurrentBuild = buildList[0];
        }

        public void Update()
        {
            PlacedBuilding();
        }

        /// <summary>
        /// 放置建筑
        /// </summary>
        private void PlacedBuilding()
        {

        }
    }

}
