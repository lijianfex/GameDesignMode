using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        throw new System.NotImplementedException();
    }

    
}