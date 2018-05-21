using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 小怪
/// </summary>
public class EnemyElf : IEnemy
{
    /// <summary>
    /// 小怪被攻击特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffeft("ElfHitEffect");
    }

    
}
