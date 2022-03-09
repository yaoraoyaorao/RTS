/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：SingletonMono
 // 创建日期：2022/3/2 12:33:16
 // 功能描述：继承mono的单例
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T Instance;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }

    }
}
