using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战士死亡，关卡系统的观察者
/// </summary>
public class SoldierkilledObserverArchievement : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;

    public SoldierkilledObserverArchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }

    public override void Update()
    {
        mAchievementSystem.AddSoldierKilledCount();
    }

    public override void SetSubject(IGameEventSubject eventSubject)
    {
        
    }

    
}