using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 模板方法模式 ：主要用于在某个行为中，其中的某个步骤可能不同，需要被重写，例如：人去吃饭的行为，都有点单，吃东西，付款的三个步骤，但由于不
/// 同地方的人，他们吃的东西会不一样。
/// </summary>
public class DM04TempleMethod : MonoBehaviour
{

    void Start()
    {
        IPeople people = new SouthPeople();
        people.Eat();
    }


}

/// <summary>
/// 模板方法的接口
/// </summary>
public abstract class IPeople
{
    /// <summary>
    /// 吃饭的行为 （模板方法）
    /// </summary>
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PayBill();
    }
    /// <summary>
    /// 点单
    /// </summary>
    private void OrderFoods()
    {
        Debug.Log("点单");
    }

    /// <summary>
    /// 吃东西
    /// </summary>
    protected virtual void EatSomething()
    {

    }
    /// <summary>
    /// 付款
    /// </summary>
    private void PayBill()
    {
        Debug.Log("付款");
    }
}

/// <summary>
/// 实现类：北方人
/// </summary>
public class NorthPeople:IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我是北方人，我吃面条！");
    }
}


public class SouthPeople:IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我是南方人，我吃米饭！");
    }
}