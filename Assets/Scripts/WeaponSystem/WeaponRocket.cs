using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public WeaponRocket(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffect(0.3f,targetPostion);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetEffectDisPlayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}
