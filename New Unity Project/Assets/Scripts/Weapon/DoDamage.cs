using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    private bool TimerOn;
    private float Timer;
    public int _Damages;
    public GameObject SkelLauncher;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.layer== 6 && collision.gameObject!=SkelLauncher)
        {
            collision.gameObject.GetComponent<SkeletonData>().TakeDamage(_Damages);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Timer = 0;
        TimerOn = true;
    }

    public void Update()
    {
        if (TimerOn)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= 5)
        {
            Destroy(gameObject);
            TimerOn = false;
        }

    }
}
