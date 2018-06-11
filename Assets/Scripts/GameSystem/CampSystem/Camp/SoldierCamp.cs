using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战士兵营
/// </summary>
public class SoldierCamp : ICamp
{
    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public override int Lv
    {
        get
        {
            return mLv;
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
            if (mLv == MAX_LV)
            {
                return -1;
            }
            return mEnergyCostCampUpLv;
        }
    }

    public override int EnergyCostWeaponUpLv
    {
        get
        {
            if(mWeaponType+1==WeaponType.MAX)
            {
                return -1;
            }
            return mEnergyCostWeaponUpLv;
        }
    }

    public override int EnergyCostTrain
    {
        get
        {
            return mEnergyCostTrain;
        }
    }

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, int lv = 1, WeaponType weaponType = WeaponType.Gun) : base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
        mEnergyCostStrategy = new SodiderEnergyCostStrategy();
        UpdateEnergyCost();
    }


    /// <summary>
    /// 训练方法
    /// </summary>
    public override void Train()
    {
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpLv = mEnergyCostStrategy.GetCampUpLvCost(mSoldierType, mLv);
        mEnergyCostWeaponUpLv = mEnergyCostStrategy.GetWeaponUpLvCost(mWeaponType);
        mEnergyCostTrain = mEnergyCostStrategy.GetSodierTrainCost(mSoldierType, mLv);
    }

    public override void CampUpLv()
    {
        //TODO升级兵营等级
        mLv++;
        //更新能量消耗策略
        UpdateEnergyCost();
    }

    public override void WeaponUpLv()
    {
        //TODO升级武器
        mWeaponType = mWeaponType + 1;
        //更新能量消耗策略
        UpdateEnergyCost();
    }
}