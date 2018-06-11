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
    private Text mTrainText;//训练按钮上的文字
    private Button mBtnTrainCancel; //取消训练
    private ICamp mCamp;

    private AliveCountVisitor aliveCountVisitor = new AliveCountVisitor();

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

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
        mTrainText = UITool.FindChild<Text>(mRootUI, "TrainText");
        mBtnTrainCancel = UITool.FindChild<Button>(mRootUI, "BtnTrainCancel");

        AddListeners();

        Hide();
    }

    private void AddListeners()
    {
        mBtnTrain.onClick.AddListener(OnTrainClick);
        mBtnTrainCancel.onClick.AddListener(OnTrainCancelClick);
        mBtnCampUpLv.onClick.AddListener(OnCampUpLvClick);
        mBtnWeaponUpLv.onClick.AddListener(OnWeaponUpLvClick);

    }

    /// <summary>
    ///显示
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfoUI(ICamp camp)
    {
        Show();
        mCamp = camp;

        mCampIcon.sprite = FactoryManager.GetAssetFactory.LoadSprite(camp.IconSprite);
        mCampName.text = camp.Name;
        ShowSodlierNumInfo(camp.SoldierType);

        isCanUpLv(camp.IsCaptiveCamp);

        ShowCampLv(camp.Lv);

        ShowWeaponLv(camp.weaponType);

        ShowTrainingInfo();

    }

    /// <summary>
    /// 显示训练信息
    /// </summary>
    private void ShowTrainingInfo()
    {
        mTrainNum.text = mCamp.TrainNum.ToString();
        mTrainTime.text = mCamp.TrainRemaingTime.ToString("0.00");
        if (mCamp.TrainNum == 0)
        {
            mBtnTrainCancel.interactable = false;
        }
        else
        {
            mBtnTrainCancel.interactable = true;
        }
    }

    /// <summary>
    /// 显示战士存活数
    /// </summary>
    /// <param name="soldierType"></param>
    private void ShowSodlierNumInfo(SoldierType soldierType)
    {
        aliveCountVisitor.Reset();
        mFacade.RunVisitor(aliveCountVisitor);
        switch (soldierType)
        {
            case SoldierType.Rookie:
                mSoldierNum.text = aliveCountVisitor.RookieCount.ToString();
                break;
            case SoldierType.Sergeant:
                mSoldierNum.text = aliveCountVisitor.SergeantCount.ToString();
                break;
            case SoldierType.Captain:
                mSoldierNum.text = aliveCountVisitor.CaptainCount.ToString();
                break;
            case SoldierType.Captive:
                mSoldierNum.text = aliveCountVisitor.CaptiveCount.ToString();
                break;
        }
    }
    /// <summary>
    /// 显示兵营的等级
    /// </summary>
    /// <param name="lv"></param>
    private void ShowCampLv(int lv)
    {
        mCampLv.text = mCamp.Lv.ToString();
        mTrainText.text = "训练\n" + mCamp.EnergyCostTrain + "点能量";
    }

    /// <summary>
    /// 显示枪的等级
    /// </summary>
    /// <param name="weaponType"></param>
    private void ShowWeaponLv(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLv.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLv.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLv.text = "火枪";
                break;
        }
    }

    //点击训练
    private void OnTrainClick()
    {
        //消耗能量,判断能量是否足够
        int energy = mCamp.EnergyCostTrain;
        if (mFacade.TakeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            mFacade.ShowMessage("训练需要能量：" + energy + "点，能量不足，无法训练新的士兵！");
        }


    }

    //取消训练
    private void OnTrainCancelClick()
    {

        mFacade.RecycleEnergy(mCamp.EnergyCostTrain); //回收能量
        mFacade.ShowMessage("取消训练，回收能量！");
        mCamp.TrainCancel();
    }

    //兵营升级
    private void OnCampUpLvClick()
    {
        int energy = mCamp.EnergyCostCampUpLv;
        if (energy < 0)
        {
            //TODO提示等级达到最大
            mFacade.ShowMessage("兵营已到最大等级，无法升级！");
            return;
        }
        //TODO 消耗能量,判断能量是否够
        if (mFacade.TakeEnergy(energy))
        {
            mCamp.CampUpLv();//升级兵营
            ShowCampLv(mCamp.Lv);//更新UI
        }
        else
        {
            mFacade.ShowMessage("升级兵营需要能量：" + energy + "点，能量不足，请稍候进行升级兵营！");
        }


    }

    //武器升级
    private void OnWeaponUpLvClick()
    {
        int energy = mCamp.EnergyCostWeaponUpLv;
        if (energy < 0)
        {
            //TODO提示等级达到最大
            mFacade.ShowMessage("武器已到最大等级，无法再进行升级！");
            return;
        }
        //TODO 消耗能量,判断能量是否够
        if (mFacade.TakeEnergy(energy))
        {
            mCamp.WeaponUpLv();//升级武器
            ShowWeaponLv(mCamp.weaponType);//更新UI
        }
        else
        {
            mFacade.ShowMessage("升级武器需要能量：" + energy + "点，能量不足，请稍候进行升级武器！");
        }


    }

    /// <summary>
    /// 是否可以升级武器与兵营
    /// </summary>
    /// <param name="isCaptiveCamp"></param>
    private void isCanUpLv(bool isCaptiveCamp)
    {
        mBtnCampUpLv.interactable = !isCaptiveCamp;
        mBtnWeaponUpLv.interactable = !isCaptiveCamp;
    }


    public override void Update()
    {
        base.Update();
        if (mCamp == null) return;

        UpdateTrainingInfo();        
        ShowSodlierNumInfo(mCamp.SoldierType);

    }

    /// <summary>
    /// 更新训练信息
    /// </summary>
    private void UpdateTrainingInfo()
    {
            ShowTrainingInfo();
    }

   
}
