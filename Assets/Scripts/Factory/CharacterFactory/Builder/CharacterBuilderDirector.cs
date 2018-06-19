using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 组装者
/// </summary>
public class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddCharacterSystem();
        return builder.GetResult();
    }
}