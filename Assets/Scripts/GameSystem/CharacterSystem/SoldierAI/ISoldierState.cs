using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战士转换状态的条件
/// </summary>
public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

/// <summary>
/// 战士的状态ID
/// </summary>
public enum SoldierStateID
{
    NullStateID=0,
    Idle,
    Chase,
    Attack
}

/// <summary>
/// 战士状态接口
/// </summary>
public abstract class ISoldierState
{
    //战士当前状态转换到其他状态的转换字典
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    //战士的当前状态ID
    protected SoldierStateID mSoldierStateID;
    public SoldierStateID stateID { get { return mSoldierStateID; } }

    protected ICharacter mCharacter; //当前状态的拥有者
    protected SoldierFSMSystem mFSM; //当前状态的管理器

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    /// <summary>
    /// 添加状态转换
    /// </summary>
    /// <param name="trans">转换条件</param>
    /// <param name="id">输出的状态ID</param>
    public void AddTransition(SoldierTransition trans,SoldierStateID id)
    {

        if(trans==SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error: trans转换条件不能为空");
            return;
        }

        if(id==SoldierStateID.NullStateID)
        {
            Debug.LogError("SoldierState Error: id状态ID不能为空");
            return;
        }

        if(mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error:" + trans + "已经添加了");
            return;
        }//以上为安全校验

        mMap.Add(trans, id);
    }

    /// <summary>
    /// 删除转换
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans)==false)
        {
            Debug.LogError("删除转换条件时，转换条件" + "[" + trans + "]" + "不存在！");
            return;
        }
        mMap.Remove(trans);
    }

    /// <summary>
    /// 下个要转换到的状态
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public SoldierStateID GetOutPutStateID(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans))
        {
            return mMap[trans];
        }
        return SoldierStateID.NullStateID;
    }

    /// <summary>
    /// 进入该状态前的操作
    /// </summary>
    public virtual void DoBeforeEntering() { }

    /// <summary>
    ///离开该状态时的操作
    /// </summary>
    public virtual void DoBeforeLeaving() { }

    /// <summary>
    /// 状态发生转换的条件
    /// </summary>
    public abstract void Reason(List<ICharacter> targets);

    /// <summary>
    /// 该状态中的操作
    /// </summary>
    public abstract void Act(List<ICharacter> targets); 

}
