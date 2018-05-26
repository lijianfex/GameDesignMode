using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun(WeaponBaseAttr baseAttr) : base(baseAttr)
    {

    }

    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffect(0.05f, targetPostion);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetEffectDisPlayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}
