using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对于战斗场景，该类利用单例实现了外观模式
/// 
/// 对于战斗场景中的各系统，该类实现了中介者模式
/// </summary>

public class GameFacade
{
    private static GameFacade _instance=new GameFacade();
    public static GameFacade Instance {get { return _instance; } }

    private bool _isGameOver=false;   //游戏是否结束
    private GameFacade() { }
    public bool IsGameOver{get {return _isGameOver;} set{ _isGameOver = value;}}

    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;
    private AchievementSystem mArchievementSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init()
    {
        mCampSystem=new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();
        mArchievementSystem = new AchievementSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();
        mArchievementSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();
    }
    public void Update()
    {
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();
        mArchievementSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();
        mArchievementSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();
    }

    /// <summary>
    /// 获取敌人目标点
    /// </summary>
    public Vector3 GetEnemyTargetPosition()
    {
        //TODO
        return mStageSystem.TargetPosition;
    }

    /// <summary>
    /// 显示兵营UI
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        mCampInfoUI.ShowCampInfoUI(camp);
    }

    /// <summary>
    /// 添加战士
    /// </summary>
    /// <param name="soldier"></param>
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }

    /// <summary>
    /// 添加敌人
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    /// <summary>
    /// 能否取走能量
    /// </summary>
    /// <param name="value"></param>
    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }

    /// <summary>
    /// 回收能量
    /// </summary>
    /// <param name="value"></param>
    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }

    /// <summary>
    /// 更新能量条
    /// </summary>
    /// <param name="nowEnergy"></param>
    /// <param name="max_Energy"></param>
    public void UpdatEnerySlider(int nowEnergy,int max_Energy)
    {
        mGameStateInfoUI.UpdataEnergySlider(nowEnergy, max_Energy);
    }

    /// <summary>
    /// 显示提示信息
    /// </summary>
    /// <param name="msg"></param>
    public void ShowMessage(string msg)
    {
        mGameStateInfoUI.Show(msg);
    }

    /// <summary>
    /// 注册事件
    /// </summary>
    /// <param name="gameEventType"></param>
    /// <param name="eventObserver"></param>
    public void RegisterObserver(GameEventType gameEventType, IGameEventObserver eventObserver)
    {
        mGameEventSystem.RegisterObserver(gameEventType, eventObserver);
    }

    /// <summary>
    ///移除事件
    /// </summary>
    /// <param name="gameEventType"></param>
    /// <param name="eventObserver"></param>
    public void RemoveObserver(GameEventType gameEventType, IGameEventObserver eventObserver)
    {
        mGameEventSystem.RegisterObserver(gameEventType, eventObserver);
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="gameEventType"></param>
    public void NotifySubject(GameEventType gameEventType)
    {
        mGameEventSystem.NotifySubject(gameEventType);
    }
}
