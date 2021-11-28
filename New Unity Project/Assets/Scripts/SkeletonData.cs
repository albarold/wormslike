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
    public void Update()
    {
        if (Life<=0)
        {
            LifeBar.GetComponent<LifeBarUpdate>().UpdateLife(0, MaxLife);
            Debug.Log("mort");
            Instantiate(GameManager.Instance.Vfx.VfxMort, gameObject.transform.position, Quaternion.identity);
            GameManager.Instance.DeleteSkeleton(GetComponent<Throwing_skeleton>());
            GameManager.Instance.CheckEnd();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int dmg)
    {
        LifeBar.GetComponent<LifeBarUpdate>().UpdateLife(Life, MaxLife);
        if (Life-dmg>0)
        {
            Life -= dmg;
        }
        
    }
   
}
