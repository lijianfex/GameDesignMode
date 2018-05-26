using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    

    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffect(0.1f, targetPostion);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffectDisPlayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}
