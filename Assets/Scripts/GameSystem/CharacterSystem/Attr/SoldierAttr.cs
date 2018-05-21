using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵特有的属性
/// </summary>
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy) : base(strategy) { }


}
