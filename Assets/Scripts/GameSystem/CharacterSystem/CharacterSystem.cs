﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色系统
/// </summary>
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mSoldiers = new List<ICharacter>();
    private List<ICharacter> mEnemys = new List<ICharacter>();


    //添加敌人
    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
        
    }

    //删除敌人
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    //添加战士
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }

    //删除战士
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }


    /// <summary>
    /// 更新
    /// </summary>
    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();

        RemoveCharacterIsKilled(mEnemys);
        RemoveCharacterIsKilled(mSoldiers);

    }


    /// <summary>
    /// 敌人更新
    /// </summary>
    private void UpdateEnemy()
    {
        foreach(IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateAIFSM(mSoldiers);
        }
    }

    /// <summary>
    ///战士更新 
    /// </summary>
    private void UpdateSoldier()
    {
        foreach(ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateAIFSM(mEnemys);
        }
    }

    /// <summary>
    /// 移除死亡角色
    /// </summary>
    /// <param name="characters"></param>
    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestroy = new List<ICharacter>();
        foreach(ICharacter s in characters)
        {
            if(s.CanDestrioy)
            {
                canDestroy.Add(s);
            }
        }
        foreach(ICharacter c in canDestroy)
        {
            c.Relase();
            characters.Remove(c);
        }
    }

    /// <summary>
    ///运行角色访问器
    /// </summary>
    /// <param name="characterVisitor"></param>
    public void RunVisitor(ICharacterVisitor characterVisitor)
    {
        foreach(ICharacter e in mEnemys)
        {
            e.RunVisitor(characterVisitor);
        }
        foreach(ICharacter s in mSoldiers )
        {
            s.RunVisitor(characterVisitor);
        }
    }
}
