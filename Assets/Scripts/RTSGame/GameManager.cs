/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：GameManager
 // 创建日期：2022/3/10 23:22:22
 // 功能描述：
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class GameManager : Singleton<GameManager>
    {

        #region 系统
        private MeshGeneration grid;                    //网格系统
        private BuildSystem buildSystem;                //建筑系统
        private PlayerController playerController;      //玩家状态控制
        #endregion

        #region 属性
        private int width;
        private int height;
        private int cellSize;
        #endregion

        public void Init()
        {
            width = 100;
            height = 100;
            cellSize = 1;

            
            grid = new MeshGeneration(width, height, cellSize);
            Debug.Log("初始化网格" + grid);

            buildSystem = new BuildSystem();
            Debug.Log("初始化建筑系统" + grid);

            playerController = new PlayerController();
            Debug.Log("初始化玩家状态" + grid);

            playerController.SetState(new ObservationState(playerController));
        }

        public void Update()
        {
            playerController.UpdateState();
        }
    }
}

