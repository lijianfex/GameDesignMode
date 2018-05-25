using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 角色的基类，抽象类，包含了角色的公有属性
/// </summary>
public abstract class ICharacter
{
    protected ICharacterAttr mAttr; //角色的属性值

    protected GameObject mGameObject;       //角色物体
    protected NavMeshAgent mNavMeshAgent;   //寻路组件
    protected AudioSource mAudioSource;     //声音源
    protected Animation mAnim;              //动画组件

    protected IWeapon mWeapon;              //角色所持有的武器

    //设置角色属性值
    public ICharacterAttr Attr { set { mAttr = value; } }

    //设置人物相关
    public GameObject GameObject
    {
        set
        {
            mGameObject = value;
            mNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudioSource = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
    }

    //设置武器
    public IWeapon Weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.Owener = this;
            //TODO 将武器设置到手上
            GameObject anchor = UnityTool.FindChild<Transform>(mGameObject, "weapon-point");
            UnityTool.AttachChild(anchor, mWeapon.GameObject);
        }
    }

    public float AtkRange { get { return mWeapon.AtkRange; } }          //攻击距离
    public float AtkColdTime { get { return mWeapon.AtkColdTime; } }    //攻击冷却时间
   
    /// <summary>
    /// 角色位置
    /// </summary>
    public Vector3 Position  
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空！");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    /// <summary>
    /// 更新角色AI状态机
    /// </summary>
    /// <param name="targets"></param>
    public abstract void UpdateAIFSM(List<ICharacter> targets);

    /// <summary>
    /// 角色的相关组件的更新
    /// </summary>
    public void Update()
    {
        mWeapon.Update();
    }

    /// <summary>
    /// 角色AI移动
    /// </summary>
    /// <param name="targetPosition">目标位置</param>
    public void MoveTo(Vector3 targetPosition)
    {
        mNavMeshAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }

    /// <summary>
    /// 攻击
    /// </summary>
    /// <param name="targetPosition">攻击目标</param>
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.Atk + mAttr.CritValue);
    }
    
    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="damage"></param>
    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);

        //被攻击的视效 只有敌人有

        //死亡特效 音效 视频效果   只有战士有
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Killed()
    {
        //TODO
    }


    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animName">动画名称</param>
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }    

    /// <summary>
    /// 播放特效
    /// </summary>
    /// <param name="effectName"></param>
    protected void DoPlayEffeft(string effectName)
    {
        //TODO 可以采取建立一个特效管理器，里面可以有个特效池，在适当的时候释放特效资源
        //1.加载特效
        //2.播放特效
        //3.销毁特效
    }

    /// <summary>
    /// 播放声音
    /// </summary>
    /// <param name="soundName"></param>
    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = null;  //TODO 可以采取建立一个音效管理器，里面可以有个音效池，在适当的时候释放音效资源
        mAudioSource.clip = clip;
        mAudioSource.Play();
    }

}
