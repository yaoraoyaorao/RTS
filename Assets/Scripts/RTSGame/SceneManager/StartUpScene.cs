/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：StartUpScene
 // 创建日期：2022/3/10 8:35:27
 // 功能描述：启动场景 预加载资源
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class StartUpScene : IScene
    {
        public StartUpScene(SceneController s) : base(s) 
        {
            SceneName = "StartUpScene";
            Type = E_SceneType.complex;
        }

        public override void EnterState()
        {
            
            GameManager.Instance.Init();
        }

        public override void EndState()
        {
            Debug.Log("结束加载");
        }

        public override void UpdataState()
        {
            
            GameManager.Instance.Update();
        }
    }

}

