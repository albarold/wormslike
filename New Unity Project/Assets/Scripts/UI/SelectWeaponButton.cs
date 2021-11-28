using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeaponButton : MonoBehaviour
{
    public GameObject[] SelectionButtons;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject SelecButton in SelectionButtons)
            {
                SelecButton.SetActive(false);
            }
            SelectionButtons[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&GameManager.Instance.Skeletons[GameManager.Instance._currentSkeleton].GetComponent<SkeletonData>().ManaFull)
        {
            foreach (GameObject SelecButton in SelectionButtons)
            {
                SelecButton.SetActive(false);
            }
            SelectionButtons[2].SetActive(true);
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (GameObject SelecButton in SelectionButtons)
            {
                SelecButton.SetActive(false);
            }
            SelectionButtons[3].SetActive(true);
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject SelecButton in SelectionButtons)
            {
                SelecButton.SetActive(false);
            }
            SelectionButtons[0].SetActive(true);
        }
    }
}
