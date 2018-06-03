using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 责任链模式（设计关卡）
/// </summary>
public class DM08ChainOfResponsibility : MonoBehaviour
{
    private void Start()
    {
        string problem = "C";
        IDMHander handerA = new DMHanderA();
        IDMHander handerB = new DMHanderB();
        IDMHander handerC = new DMHanderC();
        //handerA.NextHander = handerB;
        //handerB.NextHander = handerC;
        handerA.SetNextHander(handerB).SetNextHander(handerC);

        handerA.Hander(problem);

    }
}


public abstract class IDMHander
{

    protected IDMHander mNextHander = null;
    public IDMHander NextHander
    {
        set
        {
            mNextHander = value;
        }
    }

    public IDMHander SetNextHander(IDMHander hander)
    {
        NextHander = hander;
        return mNextHander;
    }

    public virtual void Hander(string problem) { }


}

public class DMHanderA : IDMHander
{
    public override void Hander(string problem)
    {
        if (problem == "A")
        {
            Debug.Log("处理完A问题");
        }
        else
        {
            if (mNextHander != null)
            {
                mNextHander.Hander(problem);
            }
        }

    }
}


public class DMHanderB : IDMHander
{
    public override void Hander(string problem)
    {
        if (problem == "B")
        {
            Debug.Log("处理完B问题");
        }
        else
        {
            if (mNextHander != null)
            {
                mNextHander.Hander(problem);
            }
        }
    }
}

public class DMHanderC : IDMHander
{
    public override void Hander(string problem)
    {
        if (problem == "C")
        {
            Debug.Log("处理完C问题");
        }
        else
        {
            if (mNextHander != null)
            {
                mNextHander.Hander(problem);
            }
        }
    }
}