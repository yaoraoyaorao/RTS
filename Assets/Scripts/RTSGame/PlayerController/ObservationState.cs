/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：ObservationState
 // 创建日期：2022/3/10 23:34:39
 // 功能描述：观察状态 玩家可以控制摄像机的移动 旋转 缩放
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class ObservationState:IPlayerState
    {
        private CameraController cameraController;
        public ObservationState(PlayerController p) : base(p) { }

        public override void EnterState()
        {
            cameraController = Camera.main.transform.parent.GetComponent<CameraController>();
        }

        public override void UpdateState()
        {
            cameraController.CameraMovementInputByKey();
            cameraController.CameraMovementInputByMouse();
            cameraController.CameraZoomInputByMouse();
            cameraController.CameraRotationInputByMouse();
            cameraController.CameraTransform();
        }

    }
}

