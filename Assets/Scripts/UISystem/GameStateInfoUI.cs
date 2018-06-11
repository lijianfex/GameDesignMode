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

    private float mMsgTimer = 0f;
    private float mMsgTime = 3f;

    private int currentStageNum = 1;

    private AliveCountVisitor countVisitor = new AliveCountVisitor();

    public AliveCountVisitor CountVisitor { get { return countVisitor; } }


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

        AddListeners();

        mMessage.text = "";
        mStageNum.text = currentStageNum.ToString();
        mGameOver.SetActive(false);


    }

    private void AddListeners()
    {
        mBtnPause.onClick.AddListener(OnPauseClick);
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverGameStateUI(this));
    }

    public override void Release()
    {
        base.Release();
        mFacade.RemoveObserver(GameEventType.NewStage, new NewStageObserverGameStateUI(this));
    }

    public override void Update()
    {
        base.Update();
        UpdateMessageTimer();
        UpdateAliveCount();
    }

    /// <summary>
    /// 更新能量slider
    /// </summary>
    /// <param name="nowEnergry"></param>
    /// <param name="max_Energy"></param>
    public void UpdataEnergySlider(int nowEnergry, int max_Energy)
    {
        mEnergySlider.value = nowEnergry / (float)max_Energy;
        mEnergyNum.text = "(" + nowEnergry + "/" + max_Energy + ")";
    }

    public void AddStageNum()
    {
        currentStageNum += 1;
        mStageNum.text = currentStageNum.ToString();
    }

   

    /// <summary>
    /// 显示消息
    /// </summary>
    /// <param name="msg"></param>
    public void Show(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }


    /// <summary>
    /// 更新显示消息计时器
    /// </summary>
    private void UpdateMessageTimer()
    {
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
            {
                mMessage.text = "";
            }
        }
    }

    /// <summary>
    /// 更新显示角色存活数
    /// </summary>
    private void UpdateAliveCount()
    {
        countVisitor.Reset();
        mFacade.RunVisitor(countVisitor);
        mSoldierNum.text = countVisitor.SoldierCount.ToString();
        mEnemyNum.text = countVisitor.EnemyCount.ToString();       
    }


    /// <summary>
    /// 暂停点击事件
    /// </summary>
    private void OnPauseClick()
    {
        Time.timeScale = 0;
        mFacade.ShowGamePauseUI();
    }

   
    


   
}
