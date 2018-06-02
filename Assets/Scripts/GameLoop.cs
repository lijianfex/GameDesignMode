using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    public SceneStateManager sceneStateManager=null;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
	void Start ()
    {
        sceneStateManager = new SceneStateManager();
        sceneStateManager.SetState(new StartState(sceneStateManager),false);
        
    }


    void Update ()
    {
        if(sceneStateManager!=null)
        {
            sceneStateManager.StateUpdate();
        }        
    }
}
