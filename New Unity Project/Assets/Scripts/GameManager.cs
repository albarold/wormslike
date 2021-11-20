using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    Camera cam;

    public Throwing_skeleton Skel;
    public Trajectory trajectory;
    [SerializeField]public float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    public float Waiting = 2;
    public bool MovingRound = true;
    public bool asMoved = false;

    private void Start()
    {
        cam = Camera.main;
        Skel.DesactivateRb();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            EndMovingRound();
            OnDragEnd();
            asMoved = true;
        }
        if (isDragging)
        {
            OnDrag();
        }

        if (asMoved)
        {  
            if (Skel.rb.velocity.magnitude<1.4 && Skel.OnGround)
            {

                Skel.rb.velocity = Vector2.zero;
            }
        }
    }

    public void EndMovingRound()
    {
        MovingRound = false;

    }
    void OnDragStart()
    {
        Skel.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }    
    void OnDrag()
    {
        endPoint= cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;


        force = direction * distance * pushForce;
       
        /*else
        {
            force = direction * distance * WeaponForce;
        }*/
        

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(Skel.Position, force);
        
        
    }    
    void OnDragEnd()
    {
        Skel.ActivateRb();
        
        Skel.Push(force);
        
        trajectory.Hide();
    }
}
