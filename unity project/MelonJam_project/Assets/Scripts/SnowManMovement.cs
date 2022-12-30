using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    Vector2 movementDirection;
    public float movementSpeed;
    public Animator animator;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //adjusted this to have simpler values instead of getting input twice
        animator.SetFloat("Horizontal", hMove);
        animator.SetFloat("Vertical", vMove);
        animator.SetFloat("Speed", movementSpeed);




        ProcessMovement(hMove, vMove);
    }
    void FixedUpdate()
    {
        
    }


    void ProcessMovement(float hMove, float vMove)
    {
        //establish movement direction
        movementDirection = new Vector2(hMove, vMove);
        movementDirection.Normalize();

        //apply velocity
        MyRigidBody.velocity = movementDirection * movementSpeed;
    }

}
