using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaramelWeapon : Basic_Weapon
{
    [SerializeField] [Range(0.01f, 10f)] float ThisPushForce;
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
        Candy = Instantiate(CandyPrefab,transform.parent.position + new Vector3(force.x*Distance,force.y*Distance),Quaternion.identity);
        Candy.GetComponent<Rigidbody2D>().AddForce(force * PushForce, ForceMode2D.Impulse);
        Candy.GetComponent<DoDamage>()._Damages = Candy_Damage;
        Candy.GetComponent<DoDamage>().SkelLauncher = transform.parent.gameObject.transform.parent.gameObject;
        Debug.Log(transform.parent.gameObject.transform.parent.gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==3)//ground
        {
            Debug.Log("ground contact");
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }
    }


}
