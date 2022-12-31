using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowManMovement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    Vector2 movementDirection;
    public float movementSpeed;
    public Animator animator;
    public bool canMove;
    public float rollTimer;
    public float stopTimer;
    Vector3 desiredPosition;
    public float rollSpeedY;
    public float rollSpeedX;
    public GameObject SnowFella;



    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
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
        if (canMove == true)
        {
            movementDirection = new Vector2(hMove, vMove);
            movementDirection.Normalize();

            //apply velocity
            MyRigidBody.velocity = movementDirection * movementSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("RollingTrigger"))
            {

                Debug.Log("Roll!");
                canMove = false;
                Invoke("stopmovement", stopTimer);
                   
                animator.SetInteger("isRolling", 1);
                //MyRigidBody.velocity = new Vector3(rollSpeedX, rollSpeedY, 0);
            }
        

        
    }
    public void stopmovement()
    {
        canMove = true;
    }


}
