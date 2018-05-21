using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 策略模式     针对方法会增加的需求
/// </summary>
public class DM03Strategy : MonoBehaviour
{
    void Start()
    {
        ContextStrategy context= new ContextStrategy();
        context.strategy = new ConcreatStrategyA();        
        context.CanDo();

        context.strategy = new ConcreatStrategyB();
        context.CanDo();
    }
}

/// <summary>
/// 策略持有类
/// </summary>
public class ContextStrategy
{
    public IStrategy strategy;

    public void CanDo()
    {
        strategy.CanDo();
    }
}

/// <summary>
/// 不同策略的公共接口
/// </summary>
public interface IStrategy
{
    void CanDo();
}

/// <summary>
/// 策略A
/// </summary>
public class ConcreatStrategyA : IStrategy
{
    public void CanDo()
    {
        Debug.Log("使用策略A计算");
    }
}

/// <summary>
/// 策略B
/// </summary>
public class ConcreatStrategyB : IStrategy
{
    public void CanDo()
    {
        Debug.Log("使用策略B计算");
    }
}
/// <summary>
/// 策略C
/// </summary>
public class ConcreatStrategyC : IStrategy
{
    public void CanDo()
    {
        Debug.Log("使用策略C计算");
    }
}