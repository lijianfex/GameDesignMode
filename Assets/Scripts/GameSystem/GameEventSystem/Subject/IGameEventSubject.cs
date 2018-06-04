using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏事件主题基类
/// </summary>
public abstract class IGameEventSubject 
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    //注册观察者
    public void RegisterObserver(IGameEventObserver eventObserver)
    {
        mObservers.Add(eventObserver);
    }

    //移除观察者
    public void RemoveObserver(IGameEventObserver eventObserver)
    {
        mObservers.Remove(eventObserver);
    }

    //触发器（触发观察者的行为）
    public virtual void Notify()
    {
        foreach(IGameEventObserver ob in mObservers)
        {
            ob.Update(); //触发观察者的行为
        }
    }
}