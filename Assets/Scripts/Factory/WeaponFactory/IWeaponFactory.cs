using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponFactory
{
    IWeapon CreatWeapon(WeaponType weaponType, IWeapon weapon);
}
