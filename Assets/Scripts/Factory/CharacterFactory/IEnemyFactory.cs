using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemyFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T:ICharacter,new()
    {
        ICharacter character = new T();
        #region//赋值角色的属性值
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0f;
        string iconSprite = "";
        string prefabName = "";
        System.Type t = character.GetType();
        if(t==typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if(t == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 2;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";
        }
        else if (t == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHP = 140;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";
        }
        else
        {
            Debug.LogError("类型:" + t + "不属于IEnemy,不存在此敌人！");
            return null;
        }
        #endregion
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), name, lv, maxHP, moveSpeed, iconSprite, prefabName);
        character.Attr = attr;

        //创建角色
        //1.加载资源 2.设置生成点 3.赋值给角色的GameObject
        GameObject charaterGO = FactoryManager.GetAssetFactory.LoadEnemy(prefabName);
        charaterGO.transform.position = spawnPosition;
        character.GameObject = charaterGO;

        //添加武器
        IWeapon weapon = FactoryManager.GetWeaponFactory.CreatWeapon(weaponType);
        character.Weapon = weapon;

        return character;

    }
}
