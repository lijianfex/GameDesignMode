using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人工厂
/// </summary>
public class IEnemyFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T:ICharacter,new()
    {
        ICharacter character = new T();

        ICharacterBuilder enemyBuilder = new EnemyBuilder(typeof(T), character, weaponType, spawnPosition, lv);

        return CharacterBuilderDirector.Construct(enemyBuilder);

    }
}
