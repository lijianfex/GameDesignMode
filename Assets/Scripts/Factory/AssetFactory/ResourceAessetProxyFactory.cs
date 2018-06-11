using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源加载代理
/// </summary>
public class ResourceAessetProxyFactory : IAssetFactory
{
    private ResourcesFactory mResourcesFactory = new ResourcesFactory();

    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudiClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();

    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]);
        }
        GameObject asset = mResourcesFactory.LoadAsset(ResourcesFactory.SoldierPath + name) as GameObject;
        mSoldiers.Add(name, asset);
        return GameObject.Instantiate(asset);
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemys[name]);
        }
        GameObject asset = mResourcesFactory.LoadAsset(ResourcesFactory.EnemyPath + name) as GameObject;
        mEnemys.Add(name, asset);
        return GameObject.Instantiate(asset);
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]);
        }
        GameObject asset = mResourcesFactory.LoadAsset(ResourcesFactory.WeaponPath + name) as GameObject;
        mWeapons.Add(name, asset);
        return GameObject.Instantiate(asset);
    }


    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]);
        }
        GameObject asset = mResourcesFactory.LoadAsset(ResourcesFactory.EffectPath + name) as GameObject;
        mEffects.Add(name, asset);
        return GameObject.Instantiate(asset);
    }

    public AudioClip LoadAudio(string name)
    {
        if (mAudiClips.ContainsKey(name))
        {
            return mAudiClips[name];
        }
        AudioClip audioClip = mResourcesFactory.LoadAsset(ResourcesFactory.AudioPath + name) as AudioClip;
        mAudiClips.Add(name, audioClip);
        return audioClip;        
    }

    public Sprite LoadSprite(string name)
    {
        if(mSprites.ContainsKey(name))
        {
            return mSprites[name];
        }
        Sprite sprite= Resources.Load(ResourcesFactory.SpritePath + name, typeof(Sprite)) as Sprite;        
        mSprites.Add(name, sprite);
        return sprite;
    }


}