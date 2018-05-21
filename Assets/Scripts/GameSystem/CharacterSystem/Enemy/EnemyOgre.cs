using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 中怪
/// </summary>
public class EnemyOgre : IEnemy
{
    /// <summary>
    /// 中怪被攻击特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("OgreHitEffect");
    }    
}
