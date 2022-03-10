/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：BuildState
 // 创建日期：2022/3/10 22:54:13
 // 功能描述：建造状态
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class BuildState : IPlayerState
    {
        public BuildState(PlayerController p) : base(p) { }


        public override void UpdateState()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("aaa");
            }
        }
    }
}

