using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

    public bool DestroyOnHit = true;
    private bool TimerOn;
    private float Timer;
    public int _Damages;
    public GameObject SkelLauncher;
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer== 6 && collision.gameObject!=SkelLauncher) //6=skelete
        {

            collision.gameObject.GetComponent<SkeletonData>().TakeDamage(_Damages);
            if (DestroyOnHit)
            {
                Destroy(gameObject);
            }
            Instantiate(GameManager.Instance.Audio.SoundFxs[0], collision.gameObject.transform.position, Quaternion.identity);

        }
        if (collision.gameObject.layer==7)// 7 = destructibles
        {
            Instantiate(GameManager.Instance.Vfx.VfxExplosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
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
