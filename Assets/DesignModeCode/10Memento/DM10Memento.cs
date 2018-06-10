using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 备忘录模式，用于成就系统数据的保存
/// </summary>
public class DM10Memento :MonoBehaviour
{
    private void Start()
    {
        //Originator originator = new Originator();

        //originator.SetState("State1");
        //originator.ShowState();

        //Memento memento = originator.CreatMemento();//创建快照

        //originator.SetState("State2");
        //originator.ShowState();

        //originator.SetMemento(memento);
        //originator.ShowState();

        CareTaker careTaker = new CareTaker(); //多备忘录保存管理器

        Originator originator = new Originator(); //发起者（内部有需要保存的类成员）

        originator.SetState("State1");//状态1
        originator.ShowState();
        careTaker.AddMemento("v1.0", originator.CreatMemento());

        originator.SetState("State2");//状态2
        originator.ShowState();
        careTaker.AddMemento("v2.0", originator.CreatMemento());

        originator.SetState("State3");//状态3
        originator.ShowState();
        careTaker.AddMemento("v3.0", originator.CreatMemento());

        originator.SetMemento(careTaker.GetMemento("v2.0"));//回到版本2
        originator.ShowState();

        originator.SetMemento(careTaker.GetMemento("v1.0"));//回到版本1
        originator.ShowState();

    }
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
        Debug.Log("Originator State:" + mState);
    }

    /// <summary>
    /// 创建备忘录
    /// </summary>
    /// <returns></returns>
    public Memento CreatMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }

    /// <summary>
    /// 恢复到某个备忘录状态
    /// </summary>
    /// <param name="memento"></param>
    public void SetMemento(Memento memento )
    {
        SetState(memento.GetState());
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

class CareTaker
{
    Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();

    /// <summary>
    /// 添加备忘录
    /// </summary>
    /// <param name="key"></param>
    /// <param name="memento"></param>
    public void AddMemento(string key,Memento memento)
    {
        mMementoDict.Add(key, memento);
    }

    /// <summary>
    /// 得到对应版本的快照
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public Memento GetMemento(string version)
    {
        if(mMementoDict.ContainsKey(version)==false)
        {
            Debug.LogError("快照字典中不包含Key:" + version);
            return null;
        }
        return mMementoDict[version];
    }
}