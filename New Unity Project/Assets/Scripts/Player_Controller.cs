using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour 
{

    public Throwing_skeleton Skel;
    public Trajectory trajectory;
    [SerializeField] public float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    public float Waiting = 2;
  
    public bool asMoved = false;
    public bool asShot = false;

    public bool moving=false;


    Camera cam;
    private void Start()
    {

        cam = Camera.main;
        Skel.DesactivateRb();
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;



                OnDragEnd();
            }
            if (isDragging)
            {
                OnDrag();
            }

        }
    }

    private void FixedUpdate()
    {
        
        if (asMoved)
        {
            Debug.Log("pataaaaaaaaaaaaaaaaaaate");
            if (Skel.OnGround && Skel.rb.velocity.y < 0)
            {
                Skel.rb.velocity *= 0.9f;

                if (Skel.rb.velocity.magnitude < 0.1f)
                {
                    Skel.rb.velocity = new Vector2(0, 0);
                }
            }
        }
    }

    void OnDragStart()
    {
        Skel.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;


        force = direction * distance;

        /*else
        {
            force = direction * distance * WeaponForce;
        }*/
        Skel.wp.SetupLaunchforce();

        Debug.DrawLine(startPoint, endPoint);
        if (moving)
        {
           trajectory.UpdateDots(Skel.Position, force*pushForce);
        }
        else
        {
            trajectory.UpdateDots(Skel.Position, force*Skel.wp.ActiveWeapon.GetComponent<Basic_Weapon>().PushForce);
        }
        


    }
    void OnDragEnd()
    {

        Skel.ActivateRb();
        if (moving)
        {
            Debug.Log("skel");
            Skel.Push(force*pushForce);
            moving = false;
            asMoved = true;
        }
        else if(!asShot)
        {
            Debug.Log("weapon");
            Skel.wp.Launch(force);
            asShot = true;
        }

       

        if (asMoved&&asShot)
        {
            asMoved = false;
            asShot = false;
            GameManager.Instance.EndOfTurn();
            
        }
        trajectory.Hide();
    }
}
