using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景状态管理类
/// </summary>
public class SceneStateManager
{
    private ISceneState mISceneState;

    private AsyncOperation mStateAO;

    private bool mIsRunStart = false;
    public void SetState(ISceneState sceneState,bool isLoadScene=true)
    {
        if (mISceneState != null)
        {
            mISceneState.StateEnd();
        }
        mISceneState = sceneState;
        if (isLoadScene)
        {
            mStateAO = SceneManager.LoadSceneAsync(mISceneState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mISceneState.StateStart();
            mIsRunStart = true;
        }
        

    }
    public void StateUpdate()
    {
        if (mStateAO != null && mStateAO.isDone == false) return;

        if (mIsRunStart == false && mStateAO != null && mStateAO.isDone == true)
        {
            mISceneState.StateStart();
            mIsRunStart = true;
        }

        if (mISceneState != null)
        {
            mISceneState.StateUpdate();
        }
    }


}