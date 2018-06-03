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

    protected List<ITrainCommand> mCommands; //训练命令

    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public abstract int Lv { get; }
    public abstract WeaponType weaponType { get; }

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