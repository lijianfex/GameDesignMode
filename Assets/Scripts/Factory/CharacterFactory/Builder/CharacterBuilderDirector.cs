using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        return builder.GetResult();
    }
}