﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器的公共基类
/// </summary>
public abstract class IWeapon
{

    protected WeaponBaseAttr mWeaponBaseAttr; //武器基础属性   

    protected GameObject mGameObject;   //武器物体
    protected ParticleSystem mParticle; //武器粒子特效
    protected LineRenderer mLine;       //子弹轨迹
    protected Light mLight;             //闪光
    protected AudioSource mAudio;       //武器音效
    protected float mEffectDisplayTime;  //攻击特效的显示时长

    protected ICharacter mOwner;        //武器拥有者

    //设置角色属性值
    public WeaponBaseAttr BaseAttr { set { mWeaponBaseAttr = value; } }
    //设置武器拥有者
    public ICharacter Owener
    {
        set
        {
            mOwner = value;
        }
    }

    //获取武器物体
    public GameObject GameObject
    {
        set
        {
            mGameObject = value;
            Transform effect = mGameObject.transform.Find("Effect");
            mParticle = effect.GetComponent<ParticleSystem>();
            mLine = effect.GetComponent<LineRenderer>();
            mLight = effect.GetComponent<Light>();
            mAudio = effect.GetComponent<AudioSource>();
            mEffectDisplayTime = mWeaponBaseAttr.EffectDisplayTime;
        }
        get
        {
            return mGameObject;
        }
    } 
    public float AtkRange { get { return mWeaponBaseAttr.AtkRange; } } //获得攻击距离
    public float AtkColdTime { get { return mWeaponBaseAttr.AtkColdTime; } } //获得攻击冷却时间
    public int Atk { get { return mWeaponBaseAttr.Atk; } } //获得攻击力

    

    /// <summary>
    /// 计时器
    /// </summary>
    public void Update()
    {
        if(mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if(mEffectDisplayTime <= 0)
            {
                DisableEffect();//关闭特效
            }
        }
    }

    /// <summary>
    /// 关闭特效
    /// </summary>
    private void DisableEffect()
    {
        mLight.enabled = false;
        mLine.enabled = false;
    }

    /// <summary>
    /// 开火
    /// </summary>
    /// <param name="targetPostion">目标位置</param>
    public virtual void Fire(Vector3 targetPostion)
    {
        //显示枪口特效与光
        PlayMuzzleEffect();

        //显示子弹轨迹特效
        PlayBulletEffect(targetPostion);

        //设置特效显示时间
        SetEffectDisPlayTime();

        //播放声音
        PlaySound();
    }

    protected abstract void SetEffectDisPlayTime();

    /// <summary>
    ///显示枪口特效与光
    /// </summary>
    protected virtual void PlayMuzzleEffect()
    {
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    /// <summary>
    /// 显示子弹轨迹特效
    /// </summary>
    protected abstract void PlayBulletEffect(Vector3 targetPostion);
    protected void DoPlayBulletEffect(float width, Vector3 targetPostion)
    {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);//设置起始点
        mLine.SetPosition(1, targetPostion);
    }

    /// <summary>
    /// 播放声音
    /// </summary>
    protected abstract void PlaySound();
    protected void DoPlaySound(string clipName)
    {
        //TODO 统一加载
        AudioClip clip = FactoryManager.GetAssetFactory.LoadAudio(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }


}
