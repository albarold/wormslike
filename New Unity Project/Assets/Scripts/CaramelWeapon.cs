using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaramelWeapon : Basic_Weapon
{
    [SerializeField] [Range(0.01f, 10f)] float PushForce;
    [SerializeField] int Candy_Damage;
    [SerializeField] GameObject CandyPrefab;
    private GameObject Candy;
    public override void Launch(Vector2 force)
    {
        Debug.Log("candy");
        Candy = Instantiate(CandyPrefab,transform.parent.position,Quaternion.identity);
        Candy.transform.parent = transform.parent.transform;
        Candy.GetComponent<Rigidbody2D>().AddForce(force * PushForce, ForceMode2D.Impulse);

    }
}
