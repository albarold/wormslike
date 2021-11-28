using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarUpdate : MonoBehaviour
{
    public Image imageLife;
    public float percent;
    public Image imageMana;
    public float Manapercent;
    public void UpdateLife(int Life, int MaxLife)
    {
        percent = (float)Life / (float)MaxLife;
        imageLife.fillAmount = percent;

    }
    public void UpdateMana(int mana, int MaxMana)
    {
        Manapercent = (float)mana / (float)MaxMana;
        imageMana.fillAmount = Manapercent;
    }
}
