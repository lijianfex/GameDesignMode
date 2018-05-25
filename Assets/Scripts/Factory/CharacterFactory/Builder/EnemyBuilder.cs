using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(System.Type t, ICharacter character, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(t, character, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        #region//赋值角色的属性值
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0f;
        string iconSprite = "";        
        if (mT == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            mPrefabName = "Enemy1";
        }
        else if (mT == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 2;
            iconSprite = "OgreIcon";
            mPrefabName = "Enemy2";
        }
        else if (mT == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHP = 140;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            mPrefabName = "Enemy3";
        }
        else
        {
            Debug.LogError("类型:" + mT + "不属于IEnemy,不存在此敌人！");           
        }
        #endregion
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), name, mLv, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色
        //1.加载资源 2.设置生成点 3.赋值给角色的GameObject
        GameObject charaterGO = FactoryManager.GetAssetFactory.LoadEnemy(mPrefabName);
        charaterGO.transform.position = mSpawnPosition;
        mCharacter.GameObject = charaterGO;
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