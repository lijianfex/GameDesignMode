using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵特有的属性
/// </summary>
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, name, maxHP, moveSpeed, iconSprite, prefabName) { }


}
