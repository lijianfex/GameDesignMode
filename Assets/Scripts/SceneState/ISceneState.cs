using UnityEngine;



public class ISceneState 
{
    private string mSceneName;

    
    public string SceneName
    {
        get { return mSceneName; }
    }

    protected SceneStateManager mSceneStateManager;

    public ISceneState(string sceneName, SceneStateManager sceneStateManager)
    {
        mSceneName = sceneName;
        mSceneStateManager = sceneStateManager;
    }

    public virtual void StateStart() { }
    public virtual void StateUpdate() { }
    public virtual void StateEnd() { }
}