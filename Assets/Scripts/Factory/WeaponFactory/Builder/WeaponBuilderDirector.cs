using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器组装者
/// </summary>
public class WeaponBuilderDirector
{   
   public static IWeapon Construct(IWeaponBuilder builder)
    {
        builder.AddWeaponAttr();
        builder.AddGameObject();
        return builder.GetResult();
    }
}