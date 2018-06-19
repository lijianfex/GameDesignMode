using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色建造者基类
/// </summary>
public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter; //成品角色

    protected System.Type mT;           //类型
    protected WeaponType mWeaponType;   //武器类型
    protected IWeapon mWeapon;          //具体武器
    protected Vector3 mSpawnPosition;      //生成点
    protected int mLv;                  //生成时的等级
    protected string mPrefabName="";    //预支名

    public ICharacterBuilder( System.Type t, ICharacter character, WeaponType weaponType,IWeapon weapon, Vector3 spawnPosition, int lv)
    {
        
        mT = t;
        mCharacter = character;
        mWeaponType = weaponType;
        mWeapon = weapon;
        mSpawnPosition = spawnPosition;
        mLv = lv;
    }

    //组装属性
    public abstract void AddCharacterAttr(); 
    //组装物体
    public abstract void AddGameObject();
    //组装武器
    public abstract void AddWeapon();

    //添加到角色系统
    public abstract void AddCharacterSystem();

    //最终的角色
    public abstract ICharacter GetResult();
}