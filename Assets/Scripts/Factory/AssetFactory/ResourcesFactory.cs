﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 从Resources本地文件中加载
/// </summary>
public class ResourcesFactory : IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }
    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public AudioClip LoadAudio(string name)
    {
        return LoadAsset(AudioPath + name) as AudioClip;
    }
    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }


    /// <summary>
    /// 实例化加载
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("加载资源失败，路径：" + path);
            return null;
        }
        return UnityEngine.GameObject.Instantiate(o) as GameObject;
    }

    /// <summary>
    /// 非实例化
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("加载资源失败，路径：" + path);
            return null;
        }
        return o;
    }
}

