using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI : IBaseUI
{
    private List<GameObject> mHearts; //心
    private Text mSoldierNum; //战士数
    private Text mEnemyNum; //敌人数
    private Text mStageNum; //关卡数

    private Button mBtnPause;//暂停

    private Slider mEnergySlider;//能量条
    private Text mEnergyNum;//能量值
    private Text mMessage;//提示信息

    private GameObject mGameOver;//游戏结束页面




    public override void Init()
    {
        base.Init();        
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateInfoUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "heart3");
        mHearts = new List<GameObject>();
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);

        mSoldierNum = UITool.FindChild<Text>(mRootUI, "SoldierNum");
        mEnemyNum = UITool.FindChild<Text>(mRootUI, "EnemyNum");
        mStageNum = UITool.FindChild<Text>(mRootUI, "StageNum");
        mBtnPause = UITool.FindChild<Button>(mRootUI, "BtnPause");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyNum = UITool.FindChild<Text>(mRootUI, "EnergyNum");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mGameOver = UnityTool.FindChild(mRootUI, "GameOver");

        mGameOver.SetActive(false);


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
