/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：MonoManager
 // 创建日期：2022/3/2 17:22:01
 // 功能描述：Mono管理类    单例模式
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager : Singleton<MonoManager>
{
    private MonoController controller;
    public MonoManager()
    {
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }

    public void AddUpdateListener(UnityAction action)
    {
        controller.AddUpdateListener(action);
    }

    public void RemoveUpdateLisener(UnityAction action)
    {
        controller.RemoveUpdateLisener(action);
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }

    public Coroutine StartCoroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }


    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return controller.StartCoroutine(methodName,value);
    }

    public void StopAllCoroutines()
    {
        controller.StopAllCoroutines();
    }

    public void StopCoroutine(IEnumerator routine)
    {
        controller.StopCoroutine(routine);
    }

    public void StopCoroutine(Coroutine routine)
    {
        controller.StopCoroutine(routine);
    }

    public void StopCoroutine(string methodName)
    {
        controller.StopCoroutine(methodName);
    }
}
