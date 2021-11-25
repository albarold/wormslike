using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonData : MonoBehaviour
{
    public int Life;
    public int MaxLife;
    public GameObject LifeBar;

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
        
    }
   
}
