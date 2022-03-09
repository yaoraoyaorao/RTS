/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：MonoController
 // 创建日期：2022/3/2 17:18:07
 // 功能描述：Mono控制
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        updateEvent?.Invoke();
    }

    public void AddUpdateListener(UnityAction action)
    {
        updateEvent += action;
    }

    public void RemoveUpdateLisener(UnityAction action)
    {
        updateEvent -= action;
    }
}
