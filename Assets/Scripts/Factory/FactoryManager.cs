using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 工厂管理器
/// </summary>
public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    /// <summary>
    /// 属性工厂
    /// </summary>
    public static IAttrFactory GetAttrFactory
    {
        get
        {
            if(mAttrFactory==null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }

    /// <summary>
    /// 资源加载工厂
    /// </summary>
    public static IAssetFactory GetAssetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                mAssetFactory = new ResourcesFactory();
            }
            return mAssetFactory;
        }
    }

    /// <summary>
    /// 战士创建工厂
    /// </summary>
    public static ICharacterFactory GetSoldierFactory
    {
        get
        {
            if (mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }

    /// <summary>
    /// 敌人创建工厂
    /// </summary>
    public static ICharacterFactory GetEnemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }

    /// <summary>
    /// 武器工厂
    /// </summary>
    public static IWeaponFactory GetWeaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }

}