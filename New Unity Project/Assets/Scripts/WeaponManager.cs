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
        ActiveWeapon = weapons[index];
    }
}
