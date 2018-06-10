using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 成就系统
/// </summary>
public class AchievementSystem : IGameSystem
{
    private int mEnemyKilledCount=0; //杀敌数；
    private int mSoldierKilledCount = 0; //战士死亡数
    private int mMaxStageLv = 1;//最大关卡数

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierkilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverArchievement(this));
    }

    /// <summary>
    /// 增加死亡敌人
    /// </summary>
    /// <param name="number"></param>
    public void AddEnemyKilledCount(int number=1)
    {
        mEnemyKilledCount += number;
        //Debug.Log("敌人死亡:" + mEnemyKilledCount);
    }

    /// <summary>
    /// 增加战士死亡数
    /// </summary>
    /// <param name="number"></param>
    public void AddSoldierKilledCount(int number=1)
    {
        mSoldierKilledCount += number;
        //Debug.Log("战士死亡:" + mSoldierKilledCount);

    }

    /// <summary>
    /// 设置最大关卡数
    /// </summary>
    /// <param name="stageLv"></param>
    public void SetMaxStageLv(int stageLv)
    {
        if(stageLv>mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
        //Debug.Log("最大关卡:" + mMaxStageLv);
    }

    public AchievementMemento CreatMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyKilledCount = mEnemyKilledCount;
        memento.SoldierKilledCount = mSoldierKilledCount;
        memento.MaxStageLv = mMaxStageLv;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.EnemyKilledCount;
        mSoldierKilledCount = memento.SoldierKilledCount;
        mMaxStageLv = memento.MaxStageLv;
    }
}
