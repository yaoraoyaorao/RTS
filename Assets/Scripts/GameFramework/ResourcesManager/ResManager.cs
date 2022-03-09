/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：ResManager
 // 创建日期：2022/3/2 17:40:22
 // 功能描述：资源加载管理
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResManager : Singleton<ResManager>
{
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public T Load<T>(string resPath)where T:Object
    {
        T res = Resources.Load<T>(resPath);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resPath"></param>
    /// <param name="collBack"></param>
    public void LoadAsync<T>(string resPath, UnityAction<T> collBack) where T:Object
    {
        MonoManager.Instance.StartCoroutine(ReallyLoadAsync(resPath, collBack));
    }

    private IEnumerator ReallyLoadAsync<T>(string resPath, UnityAction<T> collBack) where T:Object
    {
        ResourceRequest request = Resources.LoadAsync<T>(resPath);
        yield return request;
        if (request.asset is GameObject)
        {
            collBack(GameObject.Instantiate(request.asset) as T);
        }
        else
        {
            collBack(request.asset as T);
        }
    }
}
