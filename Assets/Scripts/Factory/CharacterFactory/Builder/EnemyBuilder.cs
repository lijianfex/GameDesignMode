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
        CharacterBaseAttr enemyBaseAttr = FactoryManager.GetAttrFactory.GetCharacterBaseAttr(mT);

        mPrefabName = enemyBaseAttr.PrefabName;//下方添加角色需要prefabName;

        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(),  mLv, enemyBaseAttr);
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