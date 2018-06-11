using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色的公共属性类，单独拿出来作为基类，把数值提取出来
/// </summary>
public class ICharacterAttr
{
    protected CharacterBaseAttr mCharacterBaseAttr;  //角色的基础属性

    protected int mCurrentHP;       //当前HP 

    protected int mLv;              //等级（士兵的等级会改变） 敌人默认等级为1   

    //通过等级，暴击率计算：  增加的最大血量   抵御的伤害值   暴击增加的伤害 -------这些数值的计算就要采取策略模式 
    protected IAttrStrategy mStrategy;

    public int CurrentHP { get { return mCurrentHP; } } //获取当前血量
    protected int mDmgDesValue; //抵御的伤害值
    public int CritValue { get { return mStrategy.GetCritDmg(mCharacterBaseAttr.CriRate); } }//暴击增加的伤害

    public IAttrStrategy Strategy { get { return mStrategy; } }

    public CharacterBaseAttr CharacterBaseAttr { get { return mCharacterBaseAttr; } }

    public ICharacterAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr)
    {
        mStrategy = strategy;
        mLv = lv;
        mCharacterBaseAttr = baseAttr;

        mDmgDesValue = mStrategy.GetDmgDescValue(mLv);//根据等级计算出抵御的伤害值
        mCurrentHP = baseAttr.MaxHP + mStrategy.GetExtraHPValue(mLv);//根据等级计算额外血量，加最大血量得到当前角色血量       


    }

    /// <summary>
    /// 更新当前血量
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        damage -= mDmgDesValue;
        if (damage < 5) damage = 5;//确保至少减少5
        mCurrentHP -= damage;
    }

}
