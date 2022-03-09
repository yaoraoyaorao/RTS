/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：ObjectPool
 // 创建日期：2022/3/2 18:01:56
 // 功能描述：对象池管理  单例模式
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectData
{
    public GameObject root;
    public List<GameObject> poolList;
    public ObjectData(GameObject obj,GameObject poolObj)
    {
        if (root == null)
        {
            root = new GameObject(obj.name + "_Root");
        }
        //root = obj;
        root.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() {};
        Push(obj);
    }

    public void Push(GameObject obj)
    {

        poolList.Add(obj);
        obj.transform.parent = root.transform;
        obj.SetActive(false);
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);

        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }
}


public class ObjectPool : Singleton<ObjectPool>
{
    private GameObject poolRoot;
    
    public Dictionary<string, ObjectData> poolDic = new Dictionary<string, ObjectData>();



    public GameObject GetObj(string resPath)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(resPath) && poolDic[resPath].poolList.Count > 0)
        {
            obj = poolDic[resPath].GetObj();
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(resPath));
            obj.name = resPath;
        }

        return obj;
    }

    public GameObject GetObj(string resPath,Vector3 pos,Quaternion quaternion)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(resPath) && poolDic[resPath].poolList.Count > 0)
        {
            obj = poolDic[resPath].GetObj();
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(resPath),pos,quaternion);
            obj.name = resPath;
        }

        return obj;
    }

    public void Push(string name,GameObject obj)
    {
        if (poolRoot==null)
        {
            poolRoot = new GameObject("PoolRoot");
        }

        obj.transform.parent = poolRoot.transform;
        obj.SetActive(false);
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].Push(obj);
        }
        else
        {
            poolDic.Add(name, new ObjectData(obj,poolRoot));
        }
    }

    public void Clear()
    {
        poolDic.Clear();
        poolRoot = null;
    }
}
