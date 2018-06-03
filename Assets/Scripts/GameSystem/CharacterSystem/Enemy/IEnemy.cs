using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy:ICharacter
{
    protected EnemyFSMSystem mEnemyFSMSystem;

    public IEnemy():base()
    {
        MakeFSM();
    }

    /// <summary>
    /// 更新状态机
    /// </summary>
    /// <param name="targets"></param>
    public override void UpdateAIFSM(List<ICharacter> targets)
    {
        if (mIsKilled) return;
        mEnemyFSMSystem.CurrentState.Reason(targets);
        mEnemyFSMSystem.CurrentState.Act(targets);        
    }

    /// <summary>
    ///创建状态机
    /// </summary>
    private void MakeFSM()
    {
        mEnemyFSMSystem = new EnemyFSMSystem();

        EnemyChaseState chaseState = new EnemyChaseState(mEnemyFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mEnemyFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mEnemyFSMSystem.AddState(chaseState, attackState);
    }

    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="damage"></param>
    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        PlayEffect();//播放敌人被攻击的特效
        if(mAttr.CurrentHP<=0)
        {
            Killed();//处理死亡
        }
    }

    /// <summary>
    /// 播放特效
    /// </summary>
    protected abstract void PlayEffect();
    
   
}
