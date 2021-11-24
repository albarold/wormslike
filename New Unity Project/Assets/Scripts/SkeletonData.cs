using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonData : MonoBehaviour
{
    public int Life;
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
