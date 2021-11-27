using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public Throwing_skeleton[] Skeletons;
    public List<Throwing_skeleton> Skeletons = new List<Throwing_skeleton>();
    public GameObject[] SpawnPoints;
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
    public GameObject PlayerMenu;
    public GameObject[] LifeBars;
    
    private int SpawnIndex=0;
    public void AddSkel(GameObject PrefabSkel)
    {
        
       
        GameObject newSkel = Instantiate(PrefabSkel, null);
        newSkel.transform.position = SpawnPoints[SpawnIndex].transform.position;
        
        SpawnIndex++;
        Skeletons.Add(newSkel.transform.GetComponent<Throwing_skeleton>());
        

        Pc.Skel = Skeletons[0];
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

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skeletons[_currentSkeleton].SetWeapon(1);
            Pc.moving = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Skeletons[_currentSkeleton].SetWeapon(2);
            Pc.moving = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Skeletons[_currentSkeleton].SetWeapon(3);
            Pc.moving = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Pc.moving = true;
        }
    }

    public void DeleteSkeleton(Throwing_skeleton Skel)
    {
        
         Skeletons.Remove(Skel);

    }

}
