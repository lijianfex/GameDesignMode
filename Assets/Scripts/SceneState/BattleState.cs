using UnityEngine;
using UnityEditor;

public class BattleState : ISceneState
{
    public BattleState(SceneStateManager sceneStateManager) : base("03Battle", sceneStateManager)
    {

    }

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateUpdate()
    {
        if(GameFacade.Instance.IsGameOver)
        {
            mSceneStateManager.SetState(new MainState(mSceneStateManager));
        }
        GameFacade.Instance.Update();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

}