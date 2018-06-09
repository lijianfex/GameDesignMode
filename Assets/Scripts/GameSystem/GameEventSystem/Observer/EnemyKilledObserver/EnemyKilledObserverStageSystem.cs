using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人死亡,关卡系统的观察者
/// </summary>
public class EnemyKilledObserverStageSystem : IGameEventObserver
{

    private EnemyKilledSubject mSubject;

    private StageSystem mStageSystem;

    public EnemyKilledObserverStageSystem(StageSystem s)
    {
        mStageSystem = s;
    }

    public override void Update()
    {
        mStageSystem.CountOfEnemykilled = mSubject.KilledCount;       
    }

    public override void SetSubject(IGameEventSubject eventSubject)
    {
        mSubject = eventSubject as EnemyKilledSubject;
    }

    
}