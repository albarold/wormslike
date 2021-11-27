using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaramelWeaponSpe : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//ground
        {
            Debug.Log("ground contact");
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }
    }
}
