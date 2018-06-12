using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBaseAttr
{
    protected string mName;             //武器名
    protected int mAtk;                 //攻击力
    protected float mAtkRange;          //攻击范围
    protected float mAtkColdTime;       //攻击冷却时间
    protected float mEffectDisplayTime;  //攻击特效的显示时长
    protected string mPrefabName;              //预支名

    public WeaponBaseAttr(string name, int atk, float atkRange, float atkColdTime, float effectDisplayTime, string prefabName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAtkColdTime = atkColdTime;
        mEffectDisplayTime = effectDisplayTime;
        mPrefabName = prefabName;
    }

    public string Name { get { return mName; } }
    public int Atk { get { return mAtk; } }
    public float AtkRange { get { return mAtkRange; } }
    public float AtkColdTime { get { return mAtkColdTime; } }
    public float EffectDisplayTime { get { return mEffectDisplayTime; } }
    public string PrefabName { get { return mPrefabName; } }

}