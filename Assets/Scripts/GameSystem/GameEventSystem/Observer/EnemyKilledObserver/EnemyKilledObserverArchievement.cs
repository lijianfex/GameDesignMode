using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人死亡，成就系统的观察者
/// </summary>
public class EnemyKilledObserverArchievement : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;

    public EnemyKilledObserverArchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }

    public override void Update()
    {
        mAchievementSystem.AddEnemyKilledCount();
    }

    public override void SetSubject(IGameEventSubject eventSubject)
    {
        
    }

    
}