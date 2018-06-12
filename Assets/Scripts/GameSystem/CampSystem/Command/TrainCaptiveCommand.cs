using UnityEngine;
using UnityEditor;

/// <summary>
/// 训练俘兵
/// </summary>
public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType=WeaponType.Gun;
    private Vector3 mSpawnPostion;
    private int mLv=1;

    public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 position, int lv = 1)
    {
        mEnemyType = enemyType;
        weaponType = mWeaponType;
        mSpawnPostion = position;
        mLv = lv;
    }


    public override void Execute()
    {
        IEnemy enemy = null;

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
                Debug.LogError("无法创建武器类型：" + mWeaponType);
                break;
        }
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.GetEnemyFactory.CreatCharacter<EnemyElf>(mWeaponType, weapon, mSpawnPostion) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.GetEnemyFactory.CreatCharacter<EnemyOgre>(mWeaponType, weapon, mSpawnPostion) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.GetEnemyFactory.CreatCharacter<EnemyTroll>(mWeaponType, weapon, mSpawnPostion) as IEnemy;
                break;
            default:
                Debug.LogError("无法创建敌人类型：" + mEnemyType);
                break;
        }

        GameFacade.Instance.RemoveEnemy(enemy);//从敌人阵营里移除

        SoldierCaptive captive = new SoldierCaptive(enemy);//适配为俘兵

        GameFacade.Instance.AddSoldier(captive);//加入战士阵营


    }
}