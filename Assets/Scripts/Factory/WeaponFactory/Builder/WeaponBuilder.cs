using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 武器建造者
/// </summary>
public class WeaponBuilder : IWeaponBuilder
{
    public WeaponBuilder(WeaponType weaponType, IWeapon weapon) : base(weaponType, weapon)
    {

    }

    public override void AddWeaponAttr()
    {
        WeaponBaseAttr weaponBaseAttr = FactoryManager.GetAttrFactory.GetWeaponBaseAttr(mWeaponType);
        mPrefabName = weaponBaseAttr.PrefabName;
        mWeapon.BaseAttr = weaponBaseAttr;
    }

    public override void AddGameObject()
    {
        mWeapon.GameObject = FactoryManager.GetAssetFactory.LoadWeapon(mPrefabName);
    }


    public override IWeapon GetResult()
    {
        return mWeapon;
    }
}