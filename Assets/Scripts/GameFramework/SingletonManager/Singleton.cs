/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：Singleton
 // 创建日期：2022/3/2 10:02:36
 // 功能描述：单例类
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T:new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
    
}
