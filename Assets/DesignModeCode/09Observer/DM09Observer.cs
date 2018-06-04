using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM09Observer : MonoBehaviour
{
    public int cat = 0;

    private ConcreteSubject1 subject1;

    public void Awake()
    {
       subject1 = new ConcreteSubject1();
    }

    private void Start()
    {

        

        ConcreteObserver1 observer1 = new ConcreteObserver1(subject1);
        subject1.RegisterObserver(observer1);

        //subject1.SubjectState = "猫进来了";  //主题的数据被赋值时，就去更新了观察者的状态 ----这句代码可以放到一个点击事件里
    }

    public void Update()
    {
        if (cat != 0)
        {
            subject1.SubjectState = "猫进来了";  //主题的数据被赋值时，就去更新了观察者的状态 ----这句代码可以放到一个点击事件里
        }        
    }
}

/// <summary>
/// 主题基类（事件基类）
/// </summary>
public abstract class Subject
{
    List<Observer> mObservers = new List<Observer>();

    public void RegisterObserver(Observer ob)
    {
        mObservers.Add(ob);
    }

    public void RemoveObserver(Observer ob)
    {
        mObservers.Remove(ob);
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void NotifyObserver()
    {
        foreach(Observer ob in mObservers)
        {
            ob.Update();
        }
    }
}

/// <summary>
/// 主题1（事件1）
/// </summary>
public class ConcreteSubject1 : Subject
{
    private string mSubjectState; //别人需要的数据

    public string SubjectState
    {
        set
        {
            mSubjectState = value;
            NotifyObserver();//当数据来了，让观察者更新
        }
        get
        {
            return mSubjectState;
        }
    }
}


/// <summary>
/// 观察者
/// </summary>
public abstract class Observer
{
    public abstract void Update(); //更新

}


public class ConcreteObserver1:Observer
{
    public ConcreteSubject1 mSub;
    public ConcreteObserver1(ConcreteSubject1 sub)
    {
        mSub = sub;
    }

    public override void Update()
    {
        Debug.Log("Obser1(老鼠)，观察到：" + mSub.SubjectState);
    }
}
   

