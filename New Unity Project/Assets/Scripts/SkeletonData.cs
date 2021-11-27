using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonData : MonoBehaviour
{
    public int Life;
    public int MaxLife;
    public GameObject LifeBar;
    [Header("caramel=0, acide= 1, chamallow= 2,chewinggum=3")]
    public int SkeletonNumber;

    public void Start()
    {
        LifeBar = GameManager.Instance.LifeBars[SkeletonNumber];
        LifeBar.SetActive(true);
    }
    public void TakeDamage(int dmg)
    {
        if (Life-dmg>0)
        {
            Life -= dmg;
        }
        else
        {
            
            GameManager.Instance.DeleteSkeleton(GetComponent<Throwing_skeleton>());
            Destroy(gameObject);
        }
        LifeBar.GetComponent<LifeBarUpdate>().UpdateLife(Life, MaxLife);
    }
   
}
