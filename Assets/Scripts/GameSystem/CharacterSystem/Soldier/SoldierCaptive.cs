using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 俘兵
/// </summary>
public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;

        ICharacterAttr attr = new ICharacterAttr(enemy.Attr.Strategy,1,enemy.Attr.CharacterBaseAttr);
        this.Attr = attr;

        this.GameObject = mEnemy.GameObject;

        this.Weapon = mEnemy.Weapon;

    }

    public override void RunVisitor(ICharacterVisitor characterVisitor)
    {
        base.RunVisitor(characterVisitor);
        characterVisitor.VisitorCaptive(this);
    }

    protected override void PlayEffect()
    {
        
    }

    protected override void PlaySound()
    {
        //DO Nothing
    }
}