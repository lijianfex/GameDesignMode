using UnityEngine;


public class TrainSoldierCommand : ITrainCommand
{
    private SoldierType mSoldierType;
    private WeaponType mWeaponType;
    private Vector3 mSpawnPostion;
    private int mLv;

    public TrainSoldierCommand(SoldierType st,WeaponType wt,Vector3 spawnPos,int lv)
    {
        mSoldierType = st;
        mWeaponType = wt;
        mSpawnPostion = spawnPos;
        mLv = lv;
    }

    public override void Execute()
    {
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
                Debug.LogError("武器类型不存在：" + mWeaponType);
                break;            
        }

        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.GetSoldierFactory.CreatCharacter<SoldierRookie>(mWeaponType, weapon, mSpawnPostion,mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.GetSoldierFactory.CreatCharacter<SoldierSergeant>(mWeaponType, weapon, mSpawnPostion, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.GetSoldierFactory.CreatCharacter<SoldierCaptain>(mWeaponType, weapon, mSpawnPostion, mLv);
                break;
            default:
                Debug.LogError("无法根据SoldierType:"+mSoldierType+"创建角色");
                break;
        }
    }
}