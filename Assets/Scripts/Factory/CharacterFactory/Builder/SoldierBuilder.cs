using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(Type t, ICharacter character, WeaponType weaponType, IWeapon weapon, Vector3 spawnPosition, int lv) : base(t, character, weaponType, weapon, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr soldierBaseAttr = FactoryManager.GetAttrFactory.GetCharacterBaseAttr(mT);

        mPrefabName = soldierBaseAttr.PrefabName;//下方添加角色需要prefabName;

        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv,soldierBaseAttr);
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
        IWeapon weapon = FactoryManager.GetWeaponFactory.CreatWeapon(mWeaponType,mWeapon);
        mCharacter.Weapon = weapon;
    }

    //添加到角色系统
    public override void AddCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}