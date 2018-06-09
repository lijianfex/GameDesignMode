using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 新关卡，成就系统的观察者
/// </summary>
public class NewStageObserverArchievement : IGameEventObserver
{
    private NewStageSubject mNewStageSubject;

    private AchievementSystem mAchievementSystem;

    public NewStageObserverArchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }    

    public override void SetSubject(IGameEventSubject eventSubject)
    {
        mNewStageSubject = eventSubject as NewStageSubject;
    }

    public override void Update()
    {
        mAchievementSystem.SetMaxStageLv(mNewStageSubject.StageCount);
    }


}