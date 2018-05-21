using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 属性值的改变策略接口
/// </summary>
public interface IAttrStrategy
{
    int GetExtraHPValue(int lv);//根据等级计算得到 增加的额外血量
    int GetDmgDescValue(int lv);//根据等级计算得到 抵御的伤害值
    int GetCritDmg(float critRate);//根据暴击率计算得到 暴击率伤害

}
