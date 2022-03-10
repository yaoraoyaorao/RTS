/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：SceneController
 // 创建日期：2022/3/10 8:36:37
 // 功能描述：场景控制
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class SceneController
    {
        private IScene currentState;

        public IScene CurrentState { get => currentState; set => currentState = value; }

        public void SetState(IScene state,bool isLoading)
        {
            if (state == null) return;
            if(currentState != null) 
                state.EndState();

            currentState = state;
            if (isLoading)
            {
                switch (state.Type)
                {
                    case E_SceneType.simple:
                        LoadSceneSetting.Instance.LoadScene(state.SceneName,state.EnterState);
                        break;
                    case E_SceneType.complex:
                        LoadSceneSetting.Instance.LoadSceneAsync(state.SceneName,state.EnterState);
                        break;
                }
                
            }
            else
            {
                state.EnterState();
            }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        public void UpdateState()
        {
            if (CurrentState != null)
                CurrentState.UpdataState();
        }
    }

}
