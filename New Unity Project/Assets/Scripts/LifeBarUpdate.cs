using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarUpdate : MonoBehaviour
{
    public Image imageLife;
    public float percent;
    public void UpdateLife(int Life, int MaxLife)
    {
        percent = (float)Life / (float)MaxLife;
        imageLife.fillAmount = percent;

    }
}
