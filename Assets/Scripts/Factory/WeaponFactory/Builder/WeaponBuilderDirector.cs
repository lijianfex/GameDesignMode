using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilderDirector
{   
   public static IWeapon Construct(IWeaponBuilder builder)
    {
        builder.AddWeaponAttr();
        builder.AddGameObject();
        return builder.GetResult();
    }
}