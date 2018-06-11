using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageObserverGameStateUI : IGameEventObserver
{
    private NewStageSubject mNewStageSubject;

    private GameStateInfoUI mGameStateInfoUI;

    public NewStageObserverGameStateUI(GameStateInfoUI gameStateInfoUI)
    {
        mGameStateInfoUI = gameStateInfoUI;
    }

    public override void SetSubject(IGameEventSubject eventSubject)
    {
        mNewStageSubject = eventSubject as NewStageSubject;
    }

    public override void Update()
    {
        mGameStateInfoUI.AddStageNum();
    }
}