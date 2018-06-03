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

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, int lv = 1, WeaponType weaponType = WeaponType.Gun) : base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
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
}