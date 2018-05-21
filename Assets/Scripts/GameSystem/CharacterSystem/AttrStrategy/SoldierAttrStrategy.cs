using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///士兵的属性值的策略
/// </summary>
public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}
