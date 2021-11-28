using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaramelWeaponSpe : MonoBehaviour
{
    public GameObject CaramelShard;
    public float CaramelShardForce;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//ground
        {
            Debug.Log("ground contact");
            GameObject go1=Instantiate(CaramelShard, transform.position, Quaternion.identity);
            go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0) * CaramelShardForce);
            GameObject go2=Instantiate(CaramelShard, transform.position, Quaternion.identity);
            go2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * CaramelShardForce);
            GameObject go3=Instantiate(CaramelShard, transform.position, Quaternion.identity);
            go3.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -1) * CaramelShardForce);
            GameObject go4=Instantiate(CaramelShard, transform.position, Quaternion.identity);
            go4.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * CaramelShardForce);
            Destroy(gameObject);

        }
    }
}
