/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：PlayerController
 // 创建日期：2022/3/10 22:51:28
 // 功能描述：玩家状态控制
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class PlayerController
    {
        private IPlayerState currentState;

        public void SetState(IPlayerState state)
        {
            if (state == null)
                return;
            if (currentState != null)
                state.EndState();
            currentState = state;
            state.EnterState();
        }

        public void UpdateState()
        {
            if (currentState != null)
                currentState.UpdateState();
        }
    }
}

