using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色工厂基类
/// </summary>
public interface ICharacterFactory
{
    ICharacter CreatCharacter<T>(WeaponType weaponType, IWeapon weapon,Vector3 spawnPostion, int lv = 1) where T:ICharacter,new();

}
