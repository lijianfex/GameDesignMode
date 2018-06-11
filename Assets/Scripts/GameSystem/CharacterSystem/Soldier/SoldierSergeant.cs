using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 中士士兵
/// </summary>
public class SoldierSergeant : ISoldier
{
    public override void RunVisitor(ICharacterVisitor characterVisitor)
    {
        base.RunVisitor(characterVisitor);
        characterVisitor.VisitorSergeant(this);
    }

    /// <summary>
    ///中士士兵死亡特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("SergeantDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("SergeantDeath");
    }
}
