using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IBaseUI
{
    private Image mCampIcon; //兵营图片
    private Text mCampName;  //兵营名字

    private Text mCampLv; //兵营等级
    private Text mWeaponLv;//武器等级

    private Button mBtnCampUpLv;//升级兵营
    private Button mBtnWeaponUpLv;//升级武器

    private Text mSoldierNum; //存活数
    private Text mTrainNum; //训练数
    private Text mTrainTime;//训练时间

    private Button mBtnTrain;//训练按钮
    private Button mBtnTrainCancel; //取消训练


    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas,"CampInfoUI"); 
        
        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLv = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLv = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mBtnCampUpLv = UITool.FindChild<Button>(mRootUI, "BtnCampUpLv");
        mBtnWeaponUpLv = UITool.FindChild<Button>(mRootUI, "BtnWeaponUpLv");
        mSoldierNum = UITool.FindChild<Text>(mRootUI, "SoldierNum");
        mTrainNum = UITool.FindChild<Text>(mRootUI, "TrainNum");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");
        mBtnTrain = UITool.FindChild<Button>(mRootUI, "BtnTrain");
        mBtnTrainCancel = UITool.FindChild<Button>(mRootUI, "BtnTrainCancel");

        Hide();
    }

    /// <summary>
    ///显示
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfoUI(ICamp camp)
    {
        Show();
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
