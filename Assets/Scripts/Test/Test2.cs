/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：Test2
 // 创建日期：2022/3/10 22:07:11
 // 功能描述：
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{

    void Start()
    {
        EventManager.Instance.AddEventListener("Death", () =>
        {
            print("死亡");
        });
    }

    void Update()
    {

    }
}
