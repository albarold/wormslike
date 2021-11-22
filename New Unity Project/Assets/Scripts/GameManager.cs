using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Throwing_skeleton[] Skeletons;
    public bool asMoved = false;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int _currentSkeleton=0;
    public Player_Controller Pc;
    public WeaponManager Wm;

    public void Start()
    {
        Wm = this.GetComponentInChildren<WeaponManager>();
    }

    public void Update()
    {
        if (Pc.asMoved)
        {
            if (_currentSkeleton <= Skeletons.Length - 1)
            {
                _currentSkeleton++;
            }
            else
            {
                _currentSkeleton = 0;
            }

            Pc.Skel = Skeletons[_currentSkeleton];
            Pc.asMoved = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skeletons[_currentSkeleton].SetWeapon(1);
            
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Wm.Weapon_2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Wm.Weapon_3();
        }*/
    }


}
