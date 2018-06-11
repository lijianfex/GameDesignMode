using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色访问器基类
/// </summary>
public abstract class ICharacterVisitor 
{
    public abstract void VisitorEnemy(IEnemy enemy);
    public abstract void VisitorSoldier(ISoldier soldier);

    public abstract void VisitorRookie(ISoldier soldier);
    public abstract void VisitorSergeant(ISoldier soldier);
    public abstract void VisitorCaptain(ISoldier soldier);
    public abstract void VisitorCaptive(ISoldier soldier);
}