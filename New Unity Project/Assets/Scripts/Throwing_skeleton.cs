using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_skeleton : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 Position { get { return transform.position; } }

    int layer_mask;

    public bool OnGround =false;
    private RaycastHit2D hitInfo;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        layer_mask = LayerMask.GetMask("Ground", "Default");
    }

    private void Update()
    {

        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z));
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, layer_mask))
            OnGround = true;
        else
        {
            Debug.Log("Not on ground");
            OnGround = false;
        }
    }

    public void Push(Vector2 force) 
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}
