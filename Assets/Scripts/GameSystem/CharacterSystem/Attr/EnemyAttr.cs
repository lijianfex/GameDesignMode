using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人特有的属性
/// </summary>
public class EnemyAttr :ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) : base(strategy, name, maxHP, moveSpeed, iconSprite, prefabName) { }
	
}
