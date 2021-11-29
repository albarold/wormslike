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

    public GameObject VictoryScreen;
    public GameObject[] VictorySkeleton;
    public int _currentSkeleton=0;
    public Player_Controller Pc;
    public GameObject PlayerMenu;
    public GameObject[] LifeBars;
    public VfxManager Vfx;
    
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
        Skeletons[_currentSkeleton].DesactiveHighLight();
        Skeletons[_currentSkeleton].GetComponent<SkeletonData>().IncreaseMana(10);
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
        Skeletons[_currentSkeleton].ActiveHighLight();
        
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skeletons[_currentSkeleton].SetWeapon(1);
            Pc.moving = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&Skeletons[_currentSkeleton].GetComponent<SkeletonData>().ManaFull)
        {

            Skeletons[_currentSkeleton].SetWeapon(2);
            Pc.moving = false;

        }
        /*if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Skeletons[_currentSkeleton].SetWeapon(3);
            Pc.moving = false;
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Pc.moving = true;
        }
    }

    public void DeleteSkeleton(Throwing_skeleton Skel)
    {
        
         Skeletons.Remove(Skel);

    }

    public void CheckEnd()
    {
        if (Skeletons.Count<=1)
        {
            VictoryScreen.SetActive(true);
            VictorySkeleton[Skeletons[_currentSkeleton].GetComponent<SkeletonData>().SkeletonNumber].SetActive(true);
            

            Debug.Log("Fin");
        }
    }
}
