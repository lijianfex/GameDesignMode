using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeaponBuilder
{
    protected IWeapon mWeapon; //武器成品
    
    protected WeaponType mWeaponType;  //类型
    protected string mPrefabName = "";    //预支名 

    public IWeaponBuilder(WeaponType weaponType,IWeapon weapon)
    {
        mWeaponType = weaponType;
        mWeapon = weapon;
    }

    //组装属性
    public abstract void AddWeaponAttr();

    //组装物体
    public abstract void AddGameObject();

    //最终的武器
    public abstract IWeapon GetResult();

}