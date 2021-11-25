using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarUpdate : MonoBehaviour
{
    public Text TextLife;

    public void UpdateLife(int Life, int MaxLife)
    {
        TextLife.text = $"{Life}/{MaxLife}";

        float percent = (float)Life / (float)MaxLife;
        

    }
}
