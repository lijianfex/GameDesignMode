using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战士兵营能量消耗策略
/// </summary>
public class SodiderEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpLvCost(SoldierType soldierType, int lv)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                Debug.LogError("无法获取" + soldierType + "升级消耗的能量值");
                break;

        }

        energy += (lv - 1) * 2;
        if (energy >= 100) energy = 100;
        return energy;
    }

    public override int GetSodierTrainCost(SoldierType soldierType, int lv)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                Debug.LogError("无法获取" + soldierType + "升级消耗的能量值");
                break;

        }

        energy += (lv - 1) * 2;
        if (energy >= 100) energy = 100;
        return energy;
    }

    public override int GetWeaponUpLvCost(WeaponType weaponType)
    {
        int energy = 0;
        switch (weaponType)
        {
            case WeaponType.Gun:
                energy = 25;
                break;
            case WeaponType.Rifle:
                energy = 35;
                break;
            case WeaponType.Rocket:
                energy = 45;
                break;
            default:
                Debug.LogError("无法获取" + weaponType + "升级消耗的能量值");
                break;            
        }
        return energy;
    }
}