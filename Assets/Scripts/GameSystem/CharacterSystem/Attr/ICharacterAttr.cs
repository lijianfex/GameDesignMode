using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色的公共属性类，单独拿出来作为基类，把数值提取出来
/// </summary>
public abstract class ICharacterAttr
{
    protected string mName;         //角色名
    protected int mMaxHP;           //最大HP
    protected float mMoveSpeed;     //移动速度

    protected int mCurrentHP;       //当前HP

    protected string mIConSprite;   //头像图片 

    protected int mLv;              //等级（士兵的等级会改变） 敌人默认等级为1
    protected float mCriRate;       //0-1的暴击率 (敌人才有暴击率) 士兵没有

    //通过等级，暴击率计算：  增加的最大血量   抵御的伤害值   暴击增加的伤害 -------这些数值的计算就要采取策略模式 
    protected IAttrStrategy mStrategy;

    protected int mDmgDesValue; //抵御的伤害值    

    public int CritValue { get { return mStrategy.GetCritDmg(mCriRate); } }//暴击增加的伤害
    public int CurrentHP { get { return mCurrentHP; } } //获取当前血量


    public ICharacterAttr(IAttrStrategy strategy)
    {
        mStrategy = strategy;
        mDmgDesValue = mStrategy.GetDmgDescValue(mLv);//根据等级计算出抵御的伤害值
        mCurrentHP = mMaxHP + mStrategy.GetExtraHPValue(mLv);//根据等级计算额外血量，加最大血量得到当前角色血量
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
