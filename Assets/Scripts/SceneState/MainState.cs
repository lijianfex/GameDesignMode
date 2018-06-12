using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainState : ISceneState
{
    private Button BtnPaly;
    private Button BtnExit;

    public MainState(SceneStateManager sceneStateManager) : base("02Main", sceneStateManager)
    {

    }



    public override void StateStart()
    {
        GameObject root = GameObject.Find("Login");
        BtnPaly = UnityTool.FindChild(root, "BtnPlay").GetComponent<Button>();
        BtnExit = UnityTool.FindChild(root, "BtnExit").GetComponent<Button>();
        BtnPaly.onClick.AddListener(OnPlayClick);
        BtnExit.onClick.AddListener(OnExitClick);
    }

    private void OnPlayClick()
    {
        mSceneStateManager.SetState(new BattleState(mSceneStateManager));
    }

    private void OnExitClick()
    {
        Application.Quit();
    }

    public override void StateEnd()
    {
        BtnPaly.onClick.RemoveAllListeners();
    }
}