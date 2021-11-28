using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGum : MonoBehaviour
{
    private int CollideNb=0;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//ground
        {
            CollideNb++;
            if (CollideNb>=3)
            {
                Destroy(gameObject);
            }
        }
    }
}
