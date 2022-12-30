using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    public Vector2 movementDirection;
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
    }
    void FixedUpdate()
    {
        
    }


    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection.Normalize();
    }
    
    void Move()
    {
        MyRigidBody.velocity = movementDirection * movementSpeed;
    }

}
