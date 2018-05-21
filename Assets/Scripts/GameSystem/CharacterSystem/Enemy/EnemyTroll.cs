using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大怪
/// </summary>
public class EnemyTroll : IEnemy
{
    /// <summary>
    /// 大怪被攻击特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("TrollHitEffect");
    }

   
}
