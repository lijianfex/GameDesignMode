using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人状态管理器
/// </summary>
public class EnemyFSMSystem
{
    //状态集合
    private List<IEnemyState> mStates;

    //当前状态
    private IEnemyState mCurrentState;
    public IEnemyState CurrentState { get { return mCurrentState; } }

    //当前状态ID
    private EnemyStateID mCurrentStateID;
    public EnemyStateID CurrentStateID { get { return mCurrentStateID; } }

    public EnemyFSMSystem()
    {
        mStates = new List<IEnemyState>();
    }


    /// <summary>
    /// 添加状态，并设置第一个添加的为初始状态
    /// </summary>
    /// <param name="state"></param>
    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("添加的状态为空！");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentStateID = state.stateID;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态ID：" + "[" + s.stateID.ToString() + "]" + "已经添加了");
                return;
            }
        }
        mStates.Add(state);

    }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            AddState(s);
        }
    }

    /// <summary>
    /// 删除某个状态
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullStateID)
        {
            Debug.LogError("要删除的状态为空状态！");
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的StateID不存在于集合中：" + stateID);
    }

    /// <summary>
    /// 执行转换状态
    /// </summary>
    /// <param name="trans"></param>
    public void PerformTranstion(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空！");
            return;
        }
        EnemyStateID nextStateID = mCurrentState.GetOutPutStateID(trans); //得到该转换条件下的下个状态ID
        if (nextStateID == EnemyStateID.NullStateID)
        {
            Debug.LogError("在转换条件：" + "[" + trans + "]" + "没有对应的转换状态！");
            return;
        }
        mCurrentStateID = nextStateID;//更新当前状态ID
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;              //更新当前状态  
                mCurrentState.DoBeforeEntering();
                break;
            }
        }

    }

}
