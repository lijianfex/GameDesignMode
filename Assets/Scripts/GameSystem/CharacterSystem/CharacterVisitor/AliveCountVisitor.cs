using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCountVisitor : ICharacterVisitor
{
    public int EnemyCount { get; private set; }
    public int SoldierCount { get; private set; }

    public int RookieCount { get; private set; }
    public int SergeantCount { get; private set; }
    public int CaptainCount { get; private set; }
    public int CaptiveCount { get; private set; }

    /// <summary>
    /// 重置
    /// </summary>
    public void Reset()
    {
        EnemyCount = 0;
        SoldierCount = 0;
        RookieCount = 0;
        SergeantCount = 0;
        CaptainCount = 0;
        CaptiveCount = 0;
    }

    public override void VisitorRookie(ISoldier soldier)
    {
        if (soldier.IsKilled == false)
        {
            RookieCount += 1;
        }
    }
    public override void VisitorSergeant(ISoldier soldier)
    {
        if (soldier.IsKilled == false)
        {
            SergeantCount += 1;
        }
    }
    public override void VisitorCaptain(ISoldier soldier)
    {
        if (soldier.IsKilled == false)
        {
            CaptainCount += 1;
        }
    }

    public override void VisitorCaptive(ISoldier soldier)
    {
        if (soldier.IsKilled == false)
        {
            CaptiveCount += 1;
        }
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