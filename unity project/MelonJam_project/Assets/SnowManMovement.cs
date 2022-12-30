using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{

    private float moveHorizontal;
    private float moveVertical;
    public Rigidbody2D MyRigidBody;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -.01f)
        {
            MyRigidBody.AddForce(new Vector2(moveHorizontal, 0f), ForceMode2D.Impulse);

        }
        if (moveVertical > 0.1f || moveVertical < -0.1f)
        {

            MyRigidBody.AddForce(new Vector2(0f, moveVertical), ForceMode2D.Impulse);
        }

    }
}
