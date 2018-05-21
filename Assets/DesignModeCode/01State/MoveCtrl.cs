using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{

    public Player player;
    
    void Start()
    {
        player = new Player();
        player.InitMoveState(new Idel());
    }

   
    void Update()
    {
       

        if (Input.GetKey(KeyCode.W))
        {
            player.HandeInput(InputDown.w);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            player.HandeInput(InputDown.s);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.HandeInput(InputDown.a);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.HandeInput(InputDown.d);
        }
        else
        {
            player.HandeInput(InputDown.i);
        }
        
    }
}

public class Player
{
    private IMoveState _moveState;

    public InputDown inputDown;

    public void InitMoveState(IMoveState moveState)
    {
        _moveState = moveState;
    }
    public void HandeInput(InputDown inputDown)
    {
        IMoveState moveState = _moveState.HandleInput(this, inputDown);
        if(moveState!=null)
        {
            _moveState.Exit(this);
            _moveState = moveState;
            _moveState.Enter(this);
        }
        _moveState.Update(this);
    }

}

public enum InputDown
{
    w,
    s,
    a,
    d,
    i
}

public class IMoveState
{
    public virtual IMoveState HandleInput(Player player, InputDown inputDown) { return null; }

    public virtual void Enter(Player player) { }
    public virtual void Update(Player player) { }
    public virtual void Exit(Player player) { }
}

public class Idel : IMoveState
{
    public override IMoveState HandleInput(Player player, InputDown inputDown)
    {
        if (inputDown == InputDown.w)
        {
            return new MoveForward();
        }
        else if (inputDown == InputDown.s)
        {
            return new MoveBack();
        }
        else if (inputDown == InputDown.d)
        {
            return new MoveRight();
        }
        else if(inputDown==InputDown.a)
        {
            return new MoveLeft();
        }
        return null;
    }

    public override void Enter(Player player)
    {
        Debug.Log("开始----等待");
    }
    public override void Update(Player player)
    {
        Debug.Log("正在----等待");
    }

    public override void Exit(Player player)
    {
        Debug.Log("结束----等待");
    }
}

public class MoveForward : IMoveState
{
    public override IMoveState HandleInput(Player player, InputDown inputDown)
    {
        if (inputDown == InputDown.s)
        {
            return new MoveBack();
        }
        else if (inputDown == InputDown.d)
        {
            return new MoveRight();
        }
        else if (inputDown == InputDown.a)
        {
            return new MoveLeft();
        }
        else if(inputDown==InputDown.i)
        {
            return new Idel();
        }
        return null;
        
    }

    public override void Enter(Player player)
    {
        Debug.Log("开始----前进");
    }
    public override void Update(Player player)
    {
        Debug.Log("正在----前进");
    }

    public override void Exit(Player player)
    {
        Debug.Log("结束----前进");
    }
}

public class MoveBack : IMoveState
{
    public override IMoveState HandleInput(Player player, InputDown inputDown)
    {
        if (inputDown == InputDown.w)
        {
            return new MoveForward();
        }
        else if (inputDown == InputDown.i)
        {
            return new Idel();
        }
        else if (inputDown == InputDown.d)
        {
            return new MoveRight();
        }
        else if (inputDown == InputDown.a)
        {
            return new MoveLeft();
        }
        return null;
    }

    public override void Enter(Player player)
    {
        Debug.Log("开始----后退");
    }
    public override void Update(Player player)
    {
        Debug.Log("正在----后退");
    }

    public override void Exit(Player player)
    {
        Debug.Log("结束----后退");
    }
}


public class MoveRight : IMoveState
{
    public override IMoveState HandleInput(Player player, InputDown inputDown)
    {

        if (inputDown == InputDown.w)
        {
            return new MoveForward();
        }
        else if (inputDown == InputDown.s)
        {
            return new MoveBack();
        }
        else if (inputDown == InputDown.i)
        {
            return new Idel();
        }
        else if (inputDown == InputDown.a)
        {
            return new MoveLeft();
        }
        return null;
    }

    public override void Enter(Player player)
    {
        Debug.Log("开始----右移");
    }
    public override void Update(Player player)
    {
        Debug.Log("正在----右移");
    }

    public override void Exit(Player player)
    {
        Debug.Log("结束----右移");
    }
}

public class MoveLeft : IMoveState
{
    public override IMoveState HandleInput(Player player, InputDown inputDown)
    {
        if (inputDown == InputDown.w)
        {
            return new MoveForward();
        }
        else if (inputDown == InputDown.s)
        {
            return new MoveBack();
        }
        else if (inputDown == InputDown.d)
        {
            return new MoveRight();
        }
        else if (inputDown == InputDown.i)
        {
            return new Idel();
        }
        return null;
    }

    public override void Enter(Player player)
    {
        Debug.Log("开始----左移");
    }
    public override void Update(Player player)
    {
        Debug.Log("正在----左移");
    }

    public override void Exit(Player player)
    {
        Debug.Log("结束----左移");
    }
}
