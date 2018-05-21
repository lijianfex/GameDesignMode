using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人的属性值策略
/// </summary>
public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        if(Random.Range(0f,1f)<critRate)
        {
            return (int)(Random.Range(.5f, 1f) * 10);
        }
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}
