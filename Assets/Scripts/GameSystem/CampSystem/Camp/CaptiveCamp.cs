using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaptiveCamp : ICamp
{
    
    private WeaponType mWeaponType = WeaponType.Gun;

    private EnemyType mEnemyType;
    public override int Lv
    {
        get
        {
            return 1;
        }
    }
    public override WeaponType weaponType
    {
        get
        {
            return mWeaponType;
        }
    }

    public override int EnergyCostCampUpLv
    {
       get
        {
            return 0;
        }
    }

    public override int EnergyCostWeaponUpLv
    {
        get
        {
            return 0;
        }
    }

    public override int EnergyCostTrain
    {
        get
        {
            return mEnergyCostTrain;
        }
    }

    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime) : base(gameObject, name, icon, SoldierType.Captive, position, trainTime)
    {
        mEnemyType = enemyType;       
        mEnergyCostStrategy = new SodiderEnergyCostStrategy();
        UpdateEnergyCost();
    }


    /// <summary>
    /// 训练方法
    /// </summary>
    public override void Train()
    {
        //添加训练命令
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mPosition);
        mCommands.Add(cmd);
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = mEnergyCostStrategy.GetSodierTrainCost(mSoldierType, 1);
    }

    public override void CampUpLv()
    {
        
    }

    public override void WeaponUpLv()
    {
       
    }
}