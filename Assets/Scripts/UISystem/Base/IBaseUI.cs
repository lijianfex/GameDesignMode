using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI基类
/// </summary>
public abstract class IBaseUI
{
    protected GameFacade mFacade;

    public GameObject mRootUI;
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    /// <summary>
    /// 显示
    /// </summary>
    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    public void Hide()
    {
        mRootUI.SetActive(false);
    }
}
