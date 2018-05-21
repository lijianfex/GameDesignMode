using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人攻击状态
/// </summary>
public class EnemyAttackState : IEnemyState
{
    private float mAtkTimer;//攻击计时器

    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mEnemyStateID = EnemyStateID.Chase;
        mAtkTimer = mCharacter.AtkColdTime;
    }


    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAtkTimer += Time.deltaTime;
        if (mAtkTimer - mCharacter.AtkColdTime >= 0.01f)
        {
            mCharacter.Attack(targets[0]);
            mAtkTimer = 0f;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTranstion(EnemyTransition.LostSoldier);
        }
        else
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance > mCharacter.AtkRange)
            {
                mFSM.PerformTranstion(EnemyTransition.LostSoldier);
            }
        }
    }
}
