using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public Throwing_skeleton[] Skeletons;
    public List<Throwing_skeleton> Skeletons = new List<Throwing_skeleton>();

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int _currentSkeleton=0;
    public Player_Controller Pc;

    public void AddSkel(GameObject PrefabSkel)
    {
        if (Skeletons.Count>=4)
        {
            Time.timeScale = 0;
        }
        Skeletons[Skeletons.Count]= Instantiate(PrefabSkel,null).transform.GetComponent<Throwing_skeleton>();
        
    }
    public void EndOfTurn()
    {
        Debug.Log("turn end");
        if (_currentSkeleton < Skeletons.Count - 1)
        {
            _currentSkeleton++;
        }
        else
        {
            _currentSkeleton = 0;
        }

        Pc.Skel = Skeletons[_currentSkeleton];
        
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skeletons[_currentSkeleton].SetWeapon(1);
            Pc.moving = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skeletons[_currentSkeleton].SetWeapon(2);
            Pc.moving = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Skeletons[_currentSkeleton].SetWeapon(3);
            Pc.moving = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Pc.moving = true;
        }
    }

    public void DeleteSkeleton(Throwing_skeleton Skel)
    {
        
         Skeletons.Remove(Skel);

    }

}
