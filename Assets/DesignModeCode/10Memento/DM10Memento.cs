using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 备忘录模式，用于成就系统数据的保存
/// </summary>
public class DM10Memento :MonoBehaviour
{

}

/// <summary>
/// 发起者
/// </summary>
class Originator
{
    private string mState;

    public void SetState(string state)
    {
        mState = state;
    }

    public void ShowState()
    {

    }

    public Memento CreatMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }

}

/// <summary>
/// 备忘录
/// </summary>
class Memento
{
    private string mState;

    public void SetState(string state)
    {
        mState = state;
    }

    public string GetState()
    {
        return mState;
    }
}