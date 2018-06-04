using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 游戏事件观察者基类
/// </summary>
public abstract class IGameEventObserver 
{
    
    public abstract void Update(); //观察者的行为
    public abstract void SetSubject(IGameEventSubject eventSubject);
}