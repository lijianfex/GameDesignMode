using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///属性工厂
/// </summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict;

    public AttrFactory()
    {
        InitCharacterBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
        mCharacterBaseAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("新人士兵", 80,2.5f,"RookieIcon","Soldier3",0f));
        mCharacterBaseAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 3f, "SergeantIcon", "Soldier2", 0f));
        mCharacterBaseAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵", 100, 3f, "CaptainIcon", "Soldier1", 0f));

        mCharacterBaseAttrDict.Add(typeof(EnemyElf), new CharacterBaseAttr("小精灵", 100, 3f, "ElfIcon", "Enemy1", 0.2f));
        mCharacterBaseAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物", 120, 2f, "OgreIcon", "Enemy2", 0.3f));
        mCharacterBaseAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("巨魔", 140, 1f, "TrollIcon", "Enemy3", 0.4f));


    }

    
    /// <summary>
    /// 获取属性
    /// </summary>
    /// <param name="t">类型</param>
    /// <returns></returns>
    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if(mCharacterBaseAttrDict.ContainsKey(t)==false)
        {
            Debug.LogError("无法根据类型："+t+ "得到角色基础属性（GetCharacterBaseAttr）");
            return null;
        }
        return mCharacterBaseAttrDict[t];
    }
}