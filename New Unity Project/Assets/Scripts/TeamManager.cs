using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public GameObject PrefabSkelType;

    public void SelectType()
    {
        gameObject.GetComponent<Button>().interactable = false;
        GameManager.Instance.AddSkel(PrefabSkelType);
        
    }
}
