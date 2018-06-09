using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏事件系统
/// </summary>
public class GameEventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }

    //private void InitGameEvents()
    //{
    //    mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
    //    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
    //    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    //}

    //注册
    public void RegisterObserver(GameEventType gameEventType,IGameEventObserver eventObserver)
    {
       
        IGameEventSubject sub =GetGameEventSubject(gameEventType);
        if (sub == null) return;
        sub.RegisterObserver(eventObserver);
        eventObserver.SetSubject(sub);
    }

    //移除
    public void RemoveObserver(GameEventType gameEventType,IGameEventObserver eventObserver)
    {
        IGameEventSubject sub = GetGameEventSubject(gameEventType);
        if (sub == null) return;
        sub.RemoveObserver(eventObserver);
        eventObserver.SetSubject(null);
    }

    private IGameEventSubject GetGameEventSubject(GameEventType gameEventType)
    {
        if (mGameEvents.ContainsKey(gameEventType) == false)
        {
            switch (gameEventType)
            {
                
                case GameEventType.EnemyKilled:
                    mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("没有对应事件类型：" + gameEventType + "的主题"); return null;
            }           
            
        }
        return mGameEvents[gameEventType];
    }


    /// <summary>
    /// 触发
    /// </summary>
    /// <param name="gameEventType"></param>
    public void NotifySubject(GameEventType gameEventType)
    {
        IGameEventSubject sub = GetGameEventSubject(gameEventType);
        if (sub == null) return;
        sub.Notify();
    }
}
