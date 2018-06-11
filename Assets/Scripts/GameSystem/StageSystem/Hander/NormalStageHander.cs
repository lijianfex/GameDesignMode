using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 普通关卡
/// </summary>
public class NormalStageHander : IStageHander
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount; //敌人数量
    private Vector3 mPosition; //生成位置

    private int mSpawnTime = 1;
    private float mSpawnTimer=0f;
    private int mCountSpawn = 0;

    

    public NormalStageHander(StageSystem stageSystem ,int lv, int countToFinished, EnemyType enemyType, WeaponType weaponType, int count, Vector3 position):base( stageSystem,lv,countToFinished)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mCount = count;
        mPosition = position;
        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if(mCountSpawn<mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if(mSpawnTimer<=0f)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
    }

    /// <summary>
    /// 产生敌人
    /// </summary>
    private void SpawnEnemy()
    {
        mCountSpawn++;
        IWeapon weapon = null;
        switch (mWeaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun();
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle();
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket();
                break;
            default:
                Debug.LogError("无法创建武器类型："+ mWeaponType);
                break;
        }
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.GetEnemyFactory.CreatCharacter<EnemyElf>(mWeaponType, weapon,mPosition);
                break;
            case EnemyType.Ogre:
                FactoryManager.GetEnemyFactory.CreatCharacter<EnemyOgre>(mWeaponType, weapon, mPosition);
                break;
            case EnemyType.Troll:
                FactoryManager.GetEnemyFactory.CreatCharacter<EnemyTroll>(mWeaponType, weapon, mPosition);
                break;
            default:
                Debug.LogError("无法创建敌人类型："+mEnemyType);
                break;
        }
    }
}