using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;

        string assetName = "";
        switch (weaponType)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                break;           
            case WeaponType.Rifle:
                assetName = "WeaponRifle";
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                break;           
        }

        IAssetFactory factory = new ResourcesFactory();
        GameObject weaponGO = factory.LoadWeapon(assetName);

        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(20, 5, weaponGO);
                break;            
            case WeaponType.Rifle:
                weapon = new WeaponRifle(30, 7, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(40, 8, weaponGO);
                break;            
        }
        return weapon;
    }
}
