using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseAttr 
{
    protected string mName;         //角色名
    protected int mMaxHP;           //最大HP
    protected float mMoveSpeed;     //移动速度
    protected string mIconSprite;   //头像图片 
    protected string mPrefabName;   //预支名
    protected float mCriRate;       //0-1的暴击率 (敌人才有暴击率) 士兵没有

    public CharacterBaseAttr(string name,int maxHP,float moveSpeed,string iconSprite,string prefabName,float criRate)
    {
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;
        mCriRate = criRate;
    }

    public string Name { get { return mName; } }
    public int MaxHP { get { return mMaxHP; } }
    public float MoveSpeed { get { return mMoveSpeed; } }
    public string IconSprite { get { return mIconSprite; } }
    public string PrefabName { get { return mPrefabName; } }
    public float CriRate { get { return mCriRate; } }
} 