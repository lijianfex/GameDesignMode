using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器工厂
/// </summary>
public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType weaponType,IWeapon weapon) 
    {        

        IWeaponBuilder weaponBuilder = new WeaponBuilder(weaponType,weapon);         

        return WeaponBuilderDirector.Construct(weaponBuilder); 
    }
}
