using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人死亡主题事件
/// </summary>
public class EnemyKilledSubject : IGameEventSubject
{
    private int mKilledCount=0;

    public int KilledCount { get { return mKilledCount; } }

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();       
    }
}