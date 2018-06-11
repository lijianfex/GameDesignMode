using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关卡系统
/// </summary>
public class StageSystem : IGameSystem
{
    private int mLv = 1;//初始化等级
    private List<Vector3> mPositions;//敌人生成位置
    private Vector3 mTargetPosition;

    private IStageHander mRootHander;

    private int mCountOfEnemyKilled = 0; //敌人的死亡数

    public int CountOfEnemykilled { set { mCountOfEnemyKilled = value; } }

    public Vector3 TargetPosition { get { return mTargetPosition; } }

    public int Lv { get { return mLv; } }

    public override void Init()
    {
        base.Init();
        InitPositon();
        InitStageChain();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));

    }

    /// <summary>
    /// 初始化生成位置
    /// </summary>
    private void InitPositon()
    {
        mPositions = new List<Vector3>();
        int i = 1;
        while(true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if(go!=null)
            {
                mPositions.Add(go.transform.position);
                i++;
                go.SetActive(false);
            }
            else
            {
                break;
            }
        }
        GameObject targetPos = GameObject.Find("TargetPosition");
        mTargetPosition = targetPos.transform.position;
        
    }

    /// <summary>
    /// 得到随机生成点
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPos()
    {
       return mPositions[UnityEngine.Random.Range(0, mPositions.Count)];
    }

    /// <summary>
    /// 初始化关卡
    /// </summary>
    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHander hander1 = new NormalStageHander(this, lv++, 3, EnemyType.Elf, WeaponType.Gun, 3,GetRandomPos());
        NormalStageHander hander2 = new NormalStageHander(this, lv++, 6, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos());
        NormalStageHander hander3 = new NormalStageHander(this, lv++, 9, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos());
        NormalStageHander hander4 = new NormalStageHander(this, lv++, 13, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHander hander5 = new NormalStageHander(this, lv++, 17, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHander hander6 = new NormalStageHander(this, lv++, 21, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHander hander7 = new NormalStageHander(this, lv++, 26, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos());
        NormalStageHander hander8 = new NormalStageHander(this, lv++, 31, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos());
        NormalStageHander hander9 = new NormalStageHander(this, lv++, 36, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos());

        hander1.SetNextHander(hander2)
            .SetNextHander(hander3)
            .SetNextHander(hander4)
            .SetNextHander(hander5)
            .SetNextHander(hander6)
            .SetNextHander(hander7)
            .SetNextHander(hander8)
            .SetNextHander(hander9);

        mRootHander = hander1;
    }


    /// <summary>
    /// 更新关卡
    /// </summary>
    public override void Update()
    {
        base.Update();
        mRootHander.Hander(mLv);
    }

    /// <summary>
    /// 得到死亡的敌人的数量，去判断是否进入下一关
    /// </summary>
    /// <returns></returns>
    public int GetCountOfEnemyKilled()
    {
        //TODO
        return mCountOfEnemyKilled;
    }

    

    public void EnterNextStage()
    {
        //TODO
        mLv++;
        mFacade.NotifySubject(GameEventType.NewStage);
    }

   
}
