using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 兵营基类
/// </summary>
public abstract class ICamp 
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;

    protected Vector3 mPosition; //集合点

    protected float mTrainTime; //训练时间

    private float mTrainTimer = 0;

    protected bool mIsCaptiveCamp = false;

    protected List<ITrainCommand> mCommands; //训练命令

    protected IEnergyCostStrategy mEnergyCostStrategy;//能量消耗策略
    protected int mEnergyCostCampUpLv;
    protected int mEnergyCostWeaponUpLv;
    protected int mEnergyCostTrain;

    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public bool IsCaptiveCamp { get { return mIsCaptiveCamp; } set { mIsCaptiveCamp = value; } }
    public SoldierType SoldierType { get { return mSoldierType; } }

    public abstract int Lv { get; }
    public abstract WeaponType weaponType { get; }
    public abstract int EnergyCostCampUpLv { get; }
    public abstract int EnergyCostWeaponUpLv { get; }
    public abstract int EnergyCostTrain { get; }

    /// <summary>
    /// 获取正在训练数
    /// </summary>
    /// <returns></returns>
    public int TrainNum
    {
        get
        {
            if (mCommands == null) return 0;
            return mCommands.Count;
        }
        
    }

    /// <summary>
    /// 剩余训练时间
    /// </summary>
    /// <returns></returns>
    public float TrainRemaingTime
    {
        get
        {
            return mTrainTimer;
        }
    }

    public ICamp(GameObject gameObject,string name,string icon,SoldierType soldierType,Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;

        mCommands = new List<ITrainCommand>();
    }

    //兵营更新相关
    public virtual void Update()
    {
        UpdateCommand();
    }

    private void UpdateCommand()
    {
        if (mCommands.Count <= 0) return;
        mTrainTimer -= Time.deltaTime;
        if(mTrainTimer<=0)
        {
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }

    }

    //训练
    public abstract void Train();
    //兵营升级
    public abstract void CampUpLv();
    //武器升级
    public abstract void WeaponUpLv();

    protected abstract void UpdateEnergyCost();

    //取消最后的命令
    public void TrainCancel()
    {
        if(mCommands.Count>0)
        {
            mCommands.RemoveAt(mCommands.Count - 1);
            if(mCommands.Count==0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }
}