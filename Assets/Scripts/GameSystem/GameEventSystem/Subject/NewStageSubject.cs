using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 关卡主题事件
/// </summary>
public class NewStageSubject : IGameEventSubject
{
    private int mStageCount = 0;
    public int StageCount { get { return mStageCount; } }

    public override void Notify()
    {
        mStageCount++;
        base.Notify();
    }
}