using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter; //成品角色

    protected System.Type mT;           //类型
    protected WeaponType mWeaponType;   //武器类型
    protected Vector3 mSpawnPosition;      //生成点
    protected int mLv;                  //生成时的等级
    protected string mPrefabName="";    //预支名

    public ICharacterBuilder( System.Type t, ICharacter character, WeaponType weaponType, Vector3 spawnPosition, int lv)
    {
        
        mT = t;
        mCharacter = character;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLv = lv;
    }

    //组装属性
    public abstract void AddCharacterAttr(); 
    //组装物体
    public abstract void AddGameObject();
    //组装武器
    public abstract void AddWeapon();

    //最终的角色
    public abstract ICharacter GetResult();
}