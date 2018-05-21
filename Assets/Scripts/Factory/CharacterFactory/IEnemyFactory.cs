using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemyFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPostion, int lv = 1) where T:ICharacter,new()
    {
        return null;
    }
}
