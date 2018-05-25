using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵工厂
/// </summary>
public class ISoldierFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        ICharacterBuilder soldierBuilder = new SoldierBuilder(typeof(T), character, weaponType, spawnPosition, lv);             

        return CharacterBuilderDirector.Construct(soldierBuilder);
    }
}
