using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 装饰模式（常用于类似buffj加成属性等）
/// </summary>
public class DM13Decorator : MonoBehaviour
{
    private void Start()
    {
        Coffee coffee = new Espress();
        coffee= coffee.AddDecorator(new Mocha());
        coffee = coffee.AddDecorator(new Milk());

        Debug.Log(coffee.Cost());

    }
}

public abstract class Coffee
{
    public abstract double Cost();
    public Coffee AddDecorator(Decorator decorator)
    {
        decorator.coffee = this;
        return decorator;
    }
}

/// <summary>
/// 浓咖啡
/// </summary>
public class Espress : Coffee
{
    public override double Cost()
    {
        return 2.5;
    }
}

/// <summary>
/// 淡咖啡
/// </summary>
public class Decaf : Coffee
{
    public override double Cost()
    {
        return 2;
    }
}

/// <summary>
/// 装饰者
/// </summary>
public class Decorator : Coffee
{
    protected Coffee mCoffee;
    public Coffee coffee { set { mCoffee = value; } }
   
    public override double Cost()
    {
        return mCoffee.Cost();
    }
}


public class Mocha : Decorator
{
    public override double Cost()
    {
        return mCoffee.Cost() + 0.5;
    }
}

public class Milk : Decorator
{
    public override double Cost()
    {
        return mCoffee.Cost() + 1;
    }
}