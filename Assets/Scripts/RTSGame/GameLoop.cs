/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：GameLoop
 // 创建日期：2022/3/10 9:01:05
 // 功能描述：游戏循环
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
public class GameLoop : MonoBehaviour
{

    private SceneController sceneController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        sceneController = new SceneController();
        sceneController.SetState(new StartUpScene(sceneController), false);
    }

    void Start()
    {
        

    }

    void Update()
    {
        if (sceneController != null)
            sceneController.UpdateState();
    }
}
