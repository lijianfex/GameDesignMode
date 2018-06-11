using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///适配器模式（伏兵营的应用）
/// </summary>
public class DM12Adapter : MonoBehaviour
{
    private void Start()
    {
        //StanderInterface adapter = new StanderImpentA();

        Adapter adapter = new Adapter(new NewPlugin());

        StanderInterface s = adapter;
        s.Request();
    }
}

interface StanderInterface
{
    void Request();
}

/// <summary>
/// 标准组件
/// </summary>
class StanderImpentA : StanderInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法实现");
    }
}


/// <summary>
/// 适配器类
/// </summary>
class Adapter:StanderInterface
{
    private NewPlugin newPlugin;

    public Adapter(NewPlugin p)
    {
        newPlugin = p;
    }

    public void Request()
    {
        newPlugin.SpecificRequest();
    }
}


/// <summary>
/// 新的插件
/// </summary>
class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("使用特殊方法实现");
    }
}
