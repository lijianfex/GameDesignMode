using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 公共枚举类
/// </summary>
public class CommoEnum{}

public enum WeaponType
{
    Gun=0,   
    Rifle=1,
    Rocket=2,
    MAX
}

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage
}


