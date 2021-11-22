using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Weapon : MonoBehaviour
{
    public float PushForce;
    [SerializeField] int Candy_Damage;
    [SerializeField] GameObject CandyPrefab;
    private GameObject Candy;
    public virtual void Launch(Vector2 force)
    {
        
    }
}
