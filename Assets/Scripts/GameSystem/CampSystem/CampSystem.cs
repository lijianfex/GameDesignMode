using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///兵营系统
/// </summary>
public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

    }

    /// <summary>
    /// 初始化兵营
    /// </summary>
    /// <param name="soldierType"></param>
    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string name ="";
        string icon = "";        
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                name = "SoldierCamp_Rookie";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                name = "SoldierCamp_Sergeant";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                name = "SoldierCamp_Captain";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                Debug.LogError("无法根据战士类型："+soldierType+"创建兵营");
                break;
        }
        gameObject = GameObject.Find(name);
        position = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position,trainTime);
        mSoldierCamps.Add(soldierType, camp);
    }


    /// <summary>
    /// 更新兵营
    /// </summary>
    public override void Update()
    {
        foreach(SoldierCamp s in mSoldierCamps.Values)
        {
            s.Update();
        }
    }

}