using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(Type t, ICharacter character, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(t, character, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        #region// 赋值角色的属性值
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0f;
        string iconSprite = "";        
        if (mT == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3f;
            iconSprite = "CaptainIcon";
            mPrefabName = "Soldier1";
        }
        else if (mT == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3f;
            iconSprite = "SergeantIcon";
            mPrefabName = "Soldier2";
        }
        else if (mT == typeof(SoldierRookie))
        {
            name = "新人士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            mPrefabName = "Soldier3";
        }
        else
        {
            Debug.LogError("类型:" + mT + "不属于ISodier,不存在战士！");            
        }
        #endregion
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), name, mLv, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {

        //创建角色
        //1.加载资源 2.设置生成点 3.赋值给角色的GameObject
        GameObject soldierGO = FactoryManager.GetAssetFactory.LoadSoldier(mPrefabName);
        soldierGO.transform.position = mSpawnPosition;
        mCharacter.GameObject = soldierGO;
    }

    public override void AddWeapon()
    {
        //添加武器        
        IWeapon weapon = FactoryManager.GetWeaponFactory.CreatWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}