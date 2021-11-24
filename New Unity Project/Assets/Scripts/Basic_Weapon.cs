using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Weapon : MonoBehaviour
{
    [HideInInspector] public float Distance = 0.2f;
    [HideInInspector] public float PushForce;
    [HideInInspector] int Candy_Damage;
    [HideInInspector] GameObject CandyPrefab;
    [HideInInspector] private GameObject Candy;

    public virtual void SetupLaunchforce()
    {

    }
    public virtual void Launch(Vector2 force)
    {
       
    }

}
