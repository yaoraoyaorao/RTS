/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：EventManager
 // 创建日期：2022/3/2 16:34:16
 // 功能描述：游戏的事件管理
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo { }

public class EventInfo<T>:IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        action += actions;
    }
}

public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        action += actions;
    }
}

public class EventManager:Singleton<EventManager>
{
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddEventListener<T>(string name,UnityAction<T> action)
    {
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name,new EventInfo<T>(action));
        }
    }

    public void AddEventListener(string name, UnityAction action)
    {
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// 移除事件监听
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }

    public void EventTrigger<T>(string name,T info)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions?.Invoke();
        }
    }

    /// <summary>
    /// 清除系统
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

}
