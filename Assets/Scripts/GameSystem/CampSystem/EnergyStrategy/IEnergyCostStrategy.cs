using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能量消耗策略
/// </summary>
public abstract class IEnergyCostStrategy 
{
    public abstract int GetCampUpLvCost(SoldierType soldierType, int lv);

    public abstract int GetWeaponUpLvCost(WeaponType weaponType);

    public abstract int GetSodierTrainCost(SoldierType soldierType, int lv);

}