using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected System.Type mT; //类型
    protected WeaponType mWeaponType; //武器类型
    protected Vector3 mSpawnPoint;  //生成点
    protected int mLv;  //生成时的等级

    public ICharacterBuilder(System.Type t,WeaponType weaponType,Vector3 spawnPoint,int lv)
    {
        mT = t;
        mWeaponType = weaponType;
        mSpawnPoint = spawnPoint;
        mLv = lv;
    }

    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
}