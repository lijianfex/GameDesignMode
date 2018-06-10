using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementMemento
{
    public int EnemyKilledCount = 0; //杀敌数；
    public int SoldierKilledCount = 0; //战士死亡数
    public int MaxStageLv = 1;//最大关卡数

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", MaxStageLv);
    }

    public void LoadData()
    {
        EnemyKilledCount= PlayerPrefs.GetInt("EnemyKilledCount");
        SoldierKilledCount= PlayerPrefs.GetInt("SoldierKilledCount");
        MaxStageLv=PlayerPrefs.GetInt("MaxStageLv");
    }
}