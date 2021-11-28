using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamallow : MonoBehaviour
{
    public Vector3 ScaleChange;
    private int CollideNb = 0;
    public int DegatSupp = 0;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//ground
        {
            gameObject.transform.localScale += ScaleChange;
            GetComponent<DoDamage>()._Damages+=DegatSupp;
            CollideNb++;
            if (CollideNb >= 3)
            {
                
                Destroy(gameObject);
            }
        }
    }
}
