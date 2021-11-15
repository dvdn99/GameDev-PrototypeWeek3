using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private bool Grounded;
    private Animator Animator;

    private Rigidbody2D Rigidbody2D;
    float Horizontal; 

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("running", Horizontal != 0.0f);

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if( Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() 
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}
