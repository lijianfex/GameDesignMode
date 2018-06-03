using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡基类
/// </summary>
public abstract class IStageHander
{
    protected int mLv;
    protected int mCountToFinished; //关卡结束的敌人死亡数
    protected StageSystem mStageSystem; //关卡系统
    protected IStageHander mNextStageHander = null;

    public IStageHander(StageSystem stageSystem, int lv, int countToFinished)
    {
        mStageSystem = stageSystem;
        mLv = lv;
        mCountToFinished = countToFinished;
    }

    
    public void Hander(int level)
    {
        if (level == mLv)
        {
            UpdateStage();
            CheckIsFinished(); //检查关卡是否结束
        }
        else
        {
            if (mNextStageHander != null)
            {
                mNextStageHander.Hander(level);
            }
        }
    }

    //设置下一关卡
    public IStageHander SetNextHander(IStageHander stageHander)
    {
        mNextStageHander = stageHander;
        return mNextStageHander;
    }

    /// <summary>
    /// 具体关卡处理
    /// </summary>
    protected virtual void UpdateStage() { }

    private void CheckIsFinished()
    {
        if(mStageSystem.GetCountOfEnemyKilled()>=mCountToFinished)
        {
            mStageSystem.EnterNextStage();
        }
    }

}