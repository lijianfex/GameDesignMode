using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态模式原型    针对对象改变，方法也改变的需求
/// </summary>

public class DM01State : MonoBehaviour
{

    public Hero hero;

    public float inputHp;

    public float initHp = 30.0f;
    void Start()
    {
        hero = new Hero(initHp,new ConcreteStateC());
        inputHp = initHp;
        
    }

    
    void FixedUpdate()
    {
        

        if (Time.frameCount%200==0)
        {
            hero.Handle(inputHp);
        }
    }
}

/// <summary>
/// 状态所有者类
/// </summary>
public class Hero
{
    private IState _state;// 英雄状态接口

    private float _hp;  //英雄血量字段

    public float Hp//英雄血量属性
    {
        get { return _hp; }
        set { _hp = value; }
    }

    
    public Hero(float hp,IState state)
    {
        _hp = hp;
        InitState(state);
    }

    /// <summary>
    /// 设置默认状态
    /// </summary>
    /// <param name="state"></param>
    public void InitState(IState state)
    {
        _state = state;
    }

    /// <summary>
    /// 根据输入改变状态
    /// </summary>
    /// <param name="hp"></param>
    public void Handle(float inputHp)
    {
        this.Hp = inputHp >= 0.0f && inputHp <= 30.0f ? inputHp : (inputHp < 0.0f ?0.0f:30.0f);

        IState state = _state.Handle(this, inputHp);
        if (state != null)
        {
            _state.End(this);
            _state = state;
            _state.Enter(this);
        }
        _state.Update(this);
    }
}


/// <summary>
/// 状态接口类
/// </summary>
public class IState
{

    public virtual IState Handle(Hero hero, float inputHp) { return null; }

    public virtual void Enter(Hero hero) { }
    public virtual void Update(Hero hero) { }

    public virtual void End(Hero hero) { }

}



/// <summary>
/// 具体状态类:A
/// </summary>
public class ConcreteStateA : IState
{

    /// <summary>
    /// 状态A的具体执行方法
    /// </summary>   
    public override IState Handle(Hero hero, float inputHp)
    {
        if (inputHp > 10.0f)
        {
            return new ConcreteStateB();
        }
        return null;
    }

    public override void Enter(Hero hero)
    {
        Debug.Log("进入状态----A----,----HP:" + hero.Hp.ToString());
    }

    public override void End(Hero hero)
    {
        Debug.Log("结束状态----A----,----HP:" + hero.Hp.ToString());
    }

    public override void Update(Hero hero)
    {
        Debug.Log("正在状态----A----,----HP:" + hero.Hp.ToString());
    }


}


/// <summary>
/// 具体状态类:B
/// </summary>
public class ConcreteStateB : IState
{

    public override IState Handle(Hero hero, float inputHp)
    {
        if (inputHp > 20.0f)
        {
            return new ConcreteStateC();
        }
        else if (inputHp < 10)
        {
            return new ConcreteStateA();
        }
        return null;
    }

    public override void Enter(Hero hero)
    {
        Debug.Log("进入状态----B----,----HP:" + hero.Hp.ToString());
    }

    public override void End(Hero hero)
    {
        Debug.Log("结束状态----B----,----HP:" + hero.Hp.ToString());
    }

    public override void Update(Hero hero)
    {
        Debug.Log("正在状态----B----,----HP:" + hero.Hp.ToString());
    }
}

/// <summary>
/// 具体状态类:C
/// </summary>
public class ConcreteStateC : IState
{

    public override IState Handle(Hero hero, float inputHp)
    {
        if (inputHp < 20.0f)
        {
            return new ConcreteStateB();
        }
        return null;
    }

    public override void Enter(Hero hero)
    {
        Debug.Log("进入状态----C----,----HP:" + hero.Hp.ToString());
    }

    public override void End(Hero hero)
    {
        Debug.Log("结束状态----C----,----HP:" + hero.Hp.ToString());
    }

    public override void Update(Hero hero)
    {
        Debug.Log("正在状态----C----,----HP:" + hero.Hp.ToString());
    }
}







