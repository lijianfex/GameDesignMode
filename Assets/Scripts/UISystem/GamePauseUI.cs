using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePauseUI : IBaseUI
{
    private Text mCurrentStageNum;//当前关卡

    private Button mBtnContinue; //继续游戏
    private Button mBtnBackMain; //返回主页


    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

        mCurrentStageNum = UITool.FindChild<Text>(mRootUI, "CurrentStageNum");
        mBtnContinue = UITool.FindChild<Button>(mRootUI, "BtnContinue");
        mBtnBackMain = UITool.FindChild<Button>(mRootUI, "BtnBackMain");

        Hide();
    }

    public void ShowGamePauseUI(int stageLv)
    {
        Show();
        mCurrentStageNum.text = stageLv.ToString();
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
