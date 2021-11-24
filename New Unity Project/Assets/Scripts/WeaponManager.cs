using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject ActiveWeapon;
    
    internal void ChangeWeapon(int index)
    {
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);

        ActiveWeapon = weapons[index-1];
        ActiveWeapon.SetActive(true);
    }

    public void Launch(Vector2 force)
    {
        ActiveWeapon.GetComponent<Basic_Weapon>().Launch(force);
    }
    public void SetupLaunchforce()
    {
        ActiveWeapon.GetComponent<Basic_Weapon>().SetupLaunchforce();
    }

}
