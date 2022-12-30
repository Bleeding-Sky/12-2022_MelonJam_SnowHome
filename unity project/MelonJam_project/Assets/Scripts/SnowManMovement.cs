using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    Vector2 movementDirection;
    public float movementSpeed;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        //calculate direction
        /*
         * 0 = up
         * 1 = right
         * 2 = down
         * 3 = left
         */

        //right
        if(hMove == 1)
        {
            animator.SetInteger("Direction", 1);
        }
        //left
        else if (hMove == -1)
        {
            animator.SetInteger("Direction", 3);
        }
        //up
        else if (vMove == 1)
        {
            animator.SetInteger("Direction", 0);
        }
        //down
        else if (vMove == -1)
        {
            animator.SetInteger("Direction", 2);
        }

        animator.SetFloat("Horizontal", hMove);
        animator.SetFloat("Vertical", vMove);

        if(hMove == 0 && vMove == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }




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
