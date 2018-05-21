using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 上尉士兵
/// </summary>
public class SoldierCaptain : ISoldier
{
    /// <summary>
    /// 上尉士兵死亡特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("CaptainDeath");
    }
}
