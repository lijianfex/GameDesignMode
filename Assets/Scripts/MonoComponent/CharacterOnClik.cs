using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色点击事件
/// </summary>
public class CharacterOnClik : MonoBehaviour
{
    private ICharacter mCharacter;
    public ICharacter Character { set { mCharacter = value; } }

    private void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowSoldierInfo(mCharacter);
    }
}