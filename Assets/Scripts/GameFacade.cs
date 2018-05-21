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

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

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

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        //TODO
        return Vector3.zero;
    }
}
