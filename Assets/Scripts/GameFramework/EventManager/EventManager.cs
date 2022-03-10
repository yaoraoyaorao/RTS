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


public interface IEventInfo
{

}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
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
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        //没有的情况
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }

    public void AddEventListener(string name, UnityAction action)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        //没有的情况
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// 移除对应的事件监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">对应之前添加的委托函数</param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions -= action;
    }

    /// <summary>
    /// 移除不需要参数的事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).actions -= action;
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">哪一个名字的事件触发了</param>
    public void EventTrigger<T>(string name, T info)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name]();
            if ((eventDic[name] as EventInfo<T>).actions != null)
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
            //eventDic[name].Invoke(info);
        }
    }

    /// <summary>
    /// 事件触发（不需要参数的）
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name]();
            if ((eventDic[name] as EventInfo).actions != null)
                (eventDic[name] as EventInfo).actions.Invoke();
            //eventDic[name].Invoke(info);
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
