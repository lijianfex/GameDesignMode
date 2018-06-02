using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainState : ISceneState
{
    private Button BtnPaly;

    public MainState(SceneStateManager sceneStateManager) : base("02Main", sceneStateManager)
    {

    }



    public override void StateStart()
    {
        GameObject root = GameObject.Find("Login");
        BtnPaly = UnityTool.FindChild(root, "BtnPlay").GetComponent<Button>();
        BtnPaly.onClick.AddListener(OnPlayClick);
    }

    private void OnPlayClick()
    {
        mSceneStateManager.SetState(new BattleState(mSceneStateManager));
    }

    public override void StateEnd()
    {
        BtnPaly.onClick.RemoveAllListeners();
    }
}