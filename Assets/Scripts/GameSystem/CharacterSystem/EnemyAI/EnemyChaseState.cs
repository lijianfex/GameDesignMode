using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人追赶状态
/// </summary>
public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mEnemyStateID = EnemyStateID.Chase;
    }

    private Vector3 mTartgetPosition;
    public override void DoBeforeEntering()
    {
        mTartgetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
        else
        {
            mCharacter.MoveTo(mTartgetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if(distance<=mCharacter.AtkRange)
            {
                mFSM.PerformTranstion(EnemyTransition.CanAttack);
            }
        }
    }
}
