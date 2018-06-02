﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 兵营基类
/// </summary>
public abstract class ICamp 
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;

    protected Vector3 mPosition; //集合点

    protected float mTrainTime; //训练时间
    public ICamp(GameObject gameObject,string name,string icon,SoldierType soldierType,Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
    }

    public virtual void Update(){ }

  
}