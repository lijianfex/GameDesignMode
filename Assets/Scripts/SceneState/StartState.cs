using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏启动开始场景
/// </summary>
public class StartState : ISceneState
{
    private Image mLogo;

    private float mColorSpeed = 1.0f;
    private float mWaitTime = 2.0f;
    
    public StartState(SceneStateManager sceneStateManager) : base("01Start", sceneStateManager)
    {

    }

    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, Time.deltaTime * mColorSpeed);
        mWaitTime -= Time.deltaTime;
        if(mWaitTime<=0)
        {
            mSceneStateManager.SetState(new MainState(mSceneStateManager));
        }
    }
}