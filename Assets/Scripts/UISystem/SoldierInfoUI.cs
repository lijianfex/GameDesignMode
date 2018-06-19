using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 战士信息UI
/// </summary>
public class SoldierInfoUI : IBaseUI
{
    private Image mSoldierIcon;//士兵头像
    private Text mSoldierName;//士兵名字

    private Text mSoldierHP; //士兵血量
    private Slider mHpSlider; //士兵血量条
    private Text mSoldierLv; //士兵等级

    private Text mAtk; //攻击力
    private Text mAtkRange;//攻击范围
    private Text mMoveSpeed; //移动速度

    private ICharacter mCharacter;

    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
        mSoldierHP = UITool.FindChild<Text>(mRootUI, "SoldierHP");
        mHpSlider = UITool.FindChild<Slider>(mRootUI, "HpSlider");
        mSoldierLv = UITool.FindChild<Text>(mRootUI, "SoldierLv");
        mAtk = UITool.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");

        Hide();
    }

    public void ShowSoldierInfoUI(ICharacter character)
    {
        if (character==null||character.IsKilled==true) return;
        Show();
        mCharacter = character;

        mSoldierIcon.sprite = FactoryManager.GetAssetFactory.LoadSprite(character.Attr.CharacterBaseAttr.IconSprite);
        mSoldierName.text = character.Attr.CharacterBaseAttr.Name;
        ShowHp(mCharacter);

        mSoldierLv.text = character.Attr.Lv.ToString();

        mAtk.text = character.Weapon.Atk.ToString();
        mAtkRange.text = character.Weapon.AtkRange.ToString();
        mMoveSpeed.text = character.Attr.CharacterBaseAttr.MoveSpeed.ToString();

    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
        ShowHp(mCharacter);
    }

    private void ShowHp(ICharacter character)
    {
        if (character == null) return;
        mSoldierHP.text =Mathf.Max(character.Attr.CurrentHP,0) + "/" + (character.Attr.CharacterBaseAttr.MaxHP + character.Attr.Strategy.GetExtraHPValue(character.Attr.Lv));
        mHpSlider.value = Mathf.Max(character.Attr.CurrentHP, 0) / (float)(character.Attr.CharacterBaseAttr.MaxHP + character.Attr.Strategy.GetExtraHPValue(character.Attr.Lv));
        if(character.CanDestrioy==true)
        {
            Hide();
        }
    }
}
