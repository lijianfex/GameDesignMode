using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵的基类
/// </summary>
public abstract class ISoldier:ICharacter
{
    protected SoldierFSMSystem mSoldierFSMSystem;

    public ISoldier():base()
    {
        MakeFSM();
    }

    /// <summary>
    /// 更新状态机
    /// </summary>
    /// <param name="targets"></param>
    public override void UpdateAIFSM(List<ICharacter> targets)
    {
        mSoldierFSMSystem.CurrentState.Reason(targets);
        mSoldierFSMSystem.CurrentState.Act(targets);
    }

    /// <summary>
    ///创建状态机
    /// </summary>
    private void MakeFSM()
    {
        mSoldierFSMSystem = new SoldierFSMSystem();
        
        SoldierIdleState idleState = new SoldierIdleState(mSoldierFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mSoldierFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mSoldierFSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mSoldierFSMSystem.AddState(idleState,chaseState,attackState);

    }

    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="damage"></param>
    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);        
        if (mAttr.CurrentHP <= 0)
        {
            PlayEffect();//死亡特效
            PlaySound();//死亡声效
            Killed();//处理死亡
        }
    }

    /// <summary>
    /// 播放特效
    /// </summary>
    protected abstract void PlayEffect();
    /// <summary>
    /// 播放声音
    /// </summary>
    protected abstract void PlaySound();
}
