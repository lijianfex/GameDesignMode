using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 新人士兵
/// </summary>
public class SoldierRookie : ISoldier
{
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
