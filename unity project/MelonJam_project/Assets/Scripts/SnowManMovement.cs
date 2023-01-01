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
    public float horizontalDirection;
    public float verticalDirection;
    public float rollTimer;
    public float stopTimer;
    Vector3 desiredPosition;
    public float rollSpeedY;
    public float rollSpeedX;
    public GameObject SnowFella;
    public GameObject Tree;
    public bool isVisible;
    public float SnowBallCount;
    public bool isNotMoving;
    public bool isShifting;
    SpriteRenderer sr;
    public Animator HillandTreeAnimator;
    public GameObject TreeHide;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isVisible = true;
        SnowBallCount = 4;
        isShifting = false;
        sr = SnowFella.GetComponent<SpriteRenderer>();
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
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");

        if (horizontalDirection == 0 && verticalDirection == 0)
        {
            isNotMoving = true;
        }
        else
        {
            isNotMoving = false;
        }
        //right
        if (hMove == 1)
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

        if(Input.GetKeyDown(KeyCode.X) && isNotMoving == true && isShifting == false)
        {
            if (SnowBallCount <= 8)
            {
                if (SnowBallCount % 2 == 0)
                {
                    SnowBallCount = SnowBallCount + 2;

                }
                else
                {
                    SnowBallCount = SnowBallCount + 3;
                }
            }
            else if(SnowBallCount <= 2)
            {
                SnowBallCount = 2;
            }
            Debug.Log(SnowBallCount);
            Debug.Log("Gather!");
            Invoke("Gather", 1);
            Invoke("Shifting", 3f);

        }
        else
        {
            animator.SetBool("isGathering", false);
        }
        if (Input.GetKeyDown(KeyCode.C) && isNotMoving == true && isShifting == false)
        {
            if (SnowBallCount >= 4)
            { 
               if(SnowBallCount % 2 == 0)
                {
                    SnowBallCount = SnowBallCount - 2;
                    Debug.Log(SnowBallCount);
                }
               else
                {
                    SnowBallCount = SnowBallCount - 1;
                    Debug.Log(SnowBallCount);
                }
                SnowBallCount = SnowBallCount - 2;
                Debug.Log("Shake!");
                Invoke("Shake", 1);
                Invoke("Shifting", 3f);
            }
            
        }
        else
        {
            animator.SetBool("isShaking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isNotMoving == true && isShifting == false)
        {
            if (SnowBallCount >= 4)
            {
                if (SnowBallCount % 2 == 1)
                {
                    SnowBallCount = SnowBallCount - 1;
                    Invoke("Shake", 0);
                    Invoke("Shifting", 3f);
                    Debug.Log("shrink");
                }
                else
                {
                    SnowBallCount = SnowBallCount - 1;
                }

            }
         
            Debug.Log(SnowBallCount);
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
        // making sprites invisible
        Debug.Log("MOvement script made snowman invisible");
        if (collision.gameObject.CompareTag("RollingTrigger"))
        {
            Invisible();
            Debug.Log("Roll!");
            SnowFella.transform.position = new Vector2(Tree.transform.position.x + .1f, Tree.transform.position.y - .05f);
            HillandTreeAnimator.SetBool("isRolling", true);
            Invoke("Hide", 0);
            Invoke("Appear", 3f);
            Invoke("Rolling", 3f);
            canMove = false;
            isVisible = false;
            MyRigidBody.velocity = new Vector2(0,0);
            
            Invoke("beginMovement", 3f);
            
            

        }
    }
    public void beginMovement()
    {
        canMove = true;
        isVisible = true;
    }

    public void Gather()
    {
        animator.SetBool("isGathering", true);
        isShifting = true;
    }

    public void Shake()
    {
        animator.SetBool("isShaking", true);
        isShifting = true;
    }
    public void Shifting()
    {
        isShifting = false;
    }
    public void Rolling()
    {
        HillandTreeAnimator.SetBool("isRolling", false);
    }

    public void Invisible()
    {
        SnowFella.GetComponent<SpriteRenderer>().color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
    }
    public void Visible()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
    }
    public void Hide()
    {
        SnowFella.transform.position = new Vector2(-1.936f, 6.21f);
    }
    public void Appear()
    {
        SnowFella.transform.position = new Vector2(-1.803f, 6.512f);
    }

}

