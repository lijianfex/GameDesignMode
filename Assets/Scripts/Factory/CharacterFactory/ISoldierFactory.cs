using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵工厂
/// </summary>
public class ISoldierFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPostion, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        #region// 赋值角色的属性值
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0f;
        string iconSprite = "";
        string prefabName = "";
        System.Type t = typeof(T);
        if (t == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3f;
            iconSprite = "CaptainIcon";
            prefabName = "Soldier1";
        }
        else if (t == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3f;
            iconSprite = "SergeantIcon";
            prefabName = "Soldier2";
        }
        else if (t == typeof(SoldierRookie))
        {
            name = "新人士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            prefabName = "Soldier3";
        }
        else
        {
            Debug.LogError("类型:" + t + "不属于ISodier,不存在战士！");
            return null;
        }
        #endregion
        ICharacterAttr attr = new ICharacterAttr(new SoldierAttrStrategy(), name, maxHP, moveSpeed, iconSprite, prefabName);

        character.Attr = attr;

        //创建角色
        //1.加载资源 2.设置生成点 3.赋值给角色的GameObject
        GameObject soldierGO = FactoryManager.GetAssetFactory.LoadSoldier(prefabName);
        soldierGO.transform.position = spawnPostion;

        character.GameObject = soldierGO;


        //添加武器        
        IWeapon weapon = FactoryManager.GetWeaponFactory.CreatWeapon(weaponType);

        character.Weapon = weapon;

        return character;
    }
}
