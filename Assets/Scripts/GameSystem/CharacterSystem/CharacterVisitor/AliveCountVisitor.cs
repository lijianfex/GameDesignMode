using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCountVisitor : ICharacterVisitor
{
    public int EnemyCount { get; private set; }
    public int SoldierCount { get; private set; }

    /// <summary>
    /// 重置
    /// </summary>
    public void Reset()
    {
        EnemyCount = 0;
        SoldierCount = 0;
    }

    public override void VisitorEnemy(IEnemy enemy)
    {
        if(enemy.IsKilled==false)
        {
            EnemyCount += 1;
        }
    }

    public override void VisitorSoldier(ISoldier soldier)
    {
        if(soldier.IsKilled==false)
        {
            SoldierCount += 1;
        }
    }
}