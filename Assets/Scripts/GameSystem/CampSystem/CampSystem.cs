using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///兵营系统
/// </summary>
public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        InitCamp(EnemyType.Elf);

    }

    /// <summary>
    /// 初始化兵营
    /// </summary>
    /// <param name="soldierType"></param>
    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name ="";
        string icon = "";        
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                Debug.LogError("无法根据战士类型："+soldierType+"创建兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        GameObject gameObjectPos = UnityTool.FindChild(gameObject, "TrainPoint");
        if(gameObjectPos!=null)
        {
            position = gameObjectPos.transform.position;
            gameObjectPos.SetActive(false);
        }        
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position,trainTime);

        gameObject.AddComponent<CampOnClick>().Camp=camp;//添加点击组件       

        mSoldierCamps.Add(soldierType, camp);
    }

    private void InitCamp(EnemyType enemyType)
    {

        GameObject gameObject = null;
        string gameObjectName = null;
        string name = "";
        string icon = "";
        Vector3 position = Vector3.zero;
        float trainTime = 0;
        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3;
                break;            
            default:
                Debug.LogError("无法根据敌人类型：" + enemyType + "初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        GameObject gameObjectPos = UnityTool.FindChild(gameObject, "TrainPoint");
        if (gameObjectPos != null)
        {
            position = gameObjectPos.transform.position;
            gameObjectPos.SetActive(false);
        }

        CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, enemyType, position, trainTime);

        gameObject.AddComponent<CampOnClick>().Camp = camp;//添加点击组件       

        mCaptiveCamps.Add(enemyType, camp);
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
        foreach(CaptiveCamp s in mCaptiveCamps.Values)
        {
            s.Update();
        }
    }

}