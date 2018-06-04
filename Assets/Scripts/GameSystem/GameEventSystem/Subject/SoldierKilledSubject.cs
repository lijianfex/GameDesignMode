using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 战士死亡主题事件
/// </summary>
public class SoldierKilledSubject : IGameEventSubject
{
    private int mKilledCount = 0;

    public int KillEdCount { get { return mKilledCount; } }

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}