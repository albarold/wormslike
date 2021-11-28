using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcideProjectile : MonoBehaviour
{
    public float PushForce;
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6 && collision.gameObject ) //6=skelete
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(((collision.gameObject.transform.position - gameObject.transform.position).normalized)*PushForce);
        }
        if (collision.gameObject.layer == 7)// 7 = destructibles
        {
            Destroy(collision.gameObject);
        }
    }
}
