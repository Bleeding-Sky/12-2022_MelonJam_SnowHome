using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
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
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = movementDirection.magnitude;
        movementDirection.Normalize();
    }
    
    void Move()
    {
        MyRigidBody.velocity = movementDirection * movementSpeed;
    }

}
