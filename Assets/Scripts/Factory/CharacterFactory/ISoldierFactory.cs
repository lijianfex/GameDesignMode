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

        //角色的属性值
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

        ICharacterAttr attr = new ICharacterAttr(new SoldierAttrStrategy(), name, maxHP, moveSpeed, iconSprite, prefabName);

        character.Attr = attr;

        //创建角色
        //1.加载资源
        //2.实例化角色

        //添加武器
        //TODO

        return character;
    }
}
