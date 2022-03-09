/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：SingletonAutoMono
 // 创建日期：2022/3/2 10:09:39
 // 功能描述：继承mono的单例基类，可以在场景中创建物体，并将脚本挂载到物体上
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAutoMono<T> :MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).ToString();
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<T>();
            }

            return instance;
        }
    }
}
