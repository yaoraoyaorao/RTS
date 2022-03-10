/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：IPlayerState
 // 创建日期：2022/3/10 22:52:18
 // 功能描述：
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class IPlayerState
    {
        private PlayerController player;

        public IPlayerState(PlayerController player)
        {
            this.Player = player;
        }

        public PlayerController Player { get => player; set => player = value; }

        public virtual void EnterState() { }
        public virtual void EndState() { }
        public virtual void UpdateState() { }
    }
}

