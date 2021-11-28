using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingGumWeapon : Basic_Weapon
{
    [SerializeField] float ThisPushForce;
    [SerializeField] int Candy_Damage;
    [SerializeField] GameObject CandyPrefab;
    private GameObject Candy;
    public override void SetupLaunchforce()
    {
        PushForce = ThisPushForce;
    }
    public override void Launch(Vector2 force)
    {
        Debug.Log("candy");
        Candy = Instantiate(CandyPrefab, transform.parent.position + new Vector3(force.x * Distance, force.y * Distance), Quaternion.identity);
        Candy.GetComponent<Rigidbody2D>().AddForce(force * PushForce, ForceMode2D.Impulse);
        Candy.GetComponent<DoDamage>()._Damages = Candy_Damage;
        Candy.GetComponent<DoDamage>().SkelLauncher = transform.parent.gameObject.transform.parent.gameObject;
        Debug.Log(transform.parent.gameObject.transform.parent.gameObject);
    }
}
