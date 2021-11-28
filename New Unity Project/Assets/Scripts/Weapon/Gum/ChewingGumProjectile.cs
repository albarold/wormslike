using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChewingGumProjectile : MonoBehaviour
{
    public GameObject SmallGum;
    public float SmallGumForce;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//ground
        {
            Debug.Log("ground contact");
            GameObject go1 = Instantiate(SmallGum, transform.position, Quaternion.identity);
            go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * SmallGumForce);
            GameObject go2 = Instantiate(SmallGum, transform.position, Quaternion.identity);
            go2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * SmallGumForce);
            Destroy(gameObject);

        }
    }
}