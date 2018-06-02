using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI : IBaseUI
{
    private Image mSoldierIcon;//士兵头像
    private Text mSoldierName;//士兵名字

    private Text mSoldierHP; //士兵血量
    private Slider mHpSlider; //士兵血量条
    private Text mSoldierLv; //士兵等级

    private Text mAtk; //攻击力
    private Text mAtkRange;//攻击范围
    private Text mMoveSpeed; //移动速度

    

    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
        mSoldierHP = UITool.FindChild<Text>(mRootUI, "SoldierHP");
        mHpSlider = UITool.FindChild<Slider>(mRootUI, "HpSlider");
        mSoldierLv = UITool.FindChild<Text>(mRootUI, "SoldierLv");
        mAtk = UITool.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");

        Hide();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }
}
