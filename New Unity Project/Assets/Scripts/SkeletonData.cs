using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonData : MonoBehaviour
{
    public int Life;
    public int MaxLife;    
    public int Mana;
    public int MaxMana=45;
    public int ManaGain=10;
    public GameObject LifeBar;
    [Header("caramel=0, acide= 1, chamallow= 2,chewinggum=3")]
    public int SkeletonNumber;
    public bool ManaFull=false;
    public void Start()
    {
        LifeBar = GameManager.Instance.LifeBars[SkeletonNumber];
        LifeBar.SetActive(true);
        LifeBar.GetComponent<LifeBarUpdate>().UpdateMana(Mana, MaxMana);
    }
    public void Update()
    {
        if (Mana>=MaxMana)
        {
            Mana = MaxMana;
            ManaFull = true;
        }
        else
        {
            ManaFull = false;
        }
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
        
        if (Life-dmg>0)
        {
            Life -= dmg;
            IncreaseMana(5);
        }
        LifeBar.GetComponent<LifeBarUpdate>().UpdateLife(Life, MaxLife);
    }
    public void IncreaseMana(int ManaGain)
    {
        Mana += ManaGain;
        LifeBar.GetComponent<LifeBarUpdate>().UpdateMana(Mana, MaxMana);
    }
}
