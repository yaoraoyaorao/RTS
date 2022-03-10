/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IScene
 // 创建日期：2022/3/10 8:33:55
 // 功能描述：场景状态基类
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class IScene
    {
        protected SceneController sceneController;
        private string sceneName;
        private E_SceneType type;
        public IScene(SceneController s,E_SceneType t = E_SceneType.simple) 
        {
            sceneController = s;
            Type = t;
        }

        public string SceneName { get => sceneName; set => sceneName = value; }
        public E_SceneType Type { get => type; set => type = value; }

        public virtual void EnterState() { }
        public virtual void EndState() { }
        public virtual void UpdataState() { }
    }
}

