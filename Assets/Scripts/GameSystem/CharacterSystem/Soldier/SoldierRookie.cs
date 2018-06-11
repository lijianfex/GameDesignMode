using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 新人士兵
/// </summary>
public class SoldierRookie : ISoldier
{
    public override void RunVisitor(ICharacterVisitor characterVisitor)
    {
        base.RunVisitor(characterVisitor);
        characterVisitor.VisitorRookie(this);
    }

    /// <summary>
    /// 新人士兵死亡特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("RookieDeath");
    }
}
