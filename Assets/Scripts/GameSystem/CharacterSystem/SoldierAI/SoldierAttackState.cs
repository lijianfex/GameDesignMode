using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战士的攻击状态
/// </summary>

public class SoldierAttackState : ISoldierState
{
    private float mAtkTimer; //攻击计时器

    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mSoldierStateID = SoldierStateID.Attack;
        mAtkTimer = mCharacter.AtkColdTime;
    }


    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAtkTimer += Time.deltaTime;
        if (mAtkTimer - mCharacter.AtkColdTime >= 0.01f)
        {
            mCharacter.Attack(targets[0]);
            mAtkTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets==null || targets.Count==0)
        {
            mFSM.PerformTranstion(SoldierTransition.NoEnemy); return;
        }
        float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
        if(distance>mCharacter.AtkRange)
        {
            mFSM.PerformTranstion(SoldierTransition.SeeEnemy);
        }
    }
}
