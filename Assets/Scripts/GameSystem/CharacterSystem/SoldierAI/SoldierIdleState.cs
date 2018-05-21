using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
///战士的Idle状态
/// </summary>
public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mSoldierStateID = SoldierStateID.Idle;
    }

    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("Stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mFSM.PerformTranstion(SoldierTransition.SeeEnemy);
        }
    }

}