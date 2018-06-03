using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能量系统
/// </summary>
public class EnergySystem : IGameSystem
{
    private const float MAX_Energy = 100f;

    private float mNowEnergy = MAX_Energy;//当前能量

    private float mRecoverSpeed = 3f; //能量恢复速度

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();
        if (mNowEnergy >= MAX_Energy) return;
        mNowEnergy += mRecoverSpeed * Time.deltaTime; //恢复能量
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }


    /// <summary>
    /// 取走能量
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TakeEnergy(int value)
    {
        if(mNowEnergy>=value)
        {
            mNowEnergy -= value;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 回收能量
    /// </summary>
    /// <param name="value"></param>
    public void RecycleEnergy(int value)
    {
        mNowEnergy += value;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }

}
