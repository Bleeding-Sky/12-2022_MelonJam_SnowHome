using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallThrowing : MonoBehaviour
{

    public GameObject snowPrefab;
    public GameObject snowPrefabUpandDown;
    public float snowVelocityinXdirectionLeftAndRight;
    public float snowVelocityinYdirectionLeftAndRight;
    public float snowVelocityinUpandDown;
    public float snowDisappear;
    public float horizontalDirection;
    public float verticalDirection;
    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        isLeft = false;
        isUp = false;
        isDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");

        //Throwing a snowball either left or right
        if(horizontalDirection > 0f)
        {
            isRight = true;
            isLeft = false;
            isUp = false;
            isDown = false;
        }
        if (horizontalDirection < 0f)
        {
            isRight = false;
            isLeft = true;
            isUp = false;
            isDown = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isRight)
        {
            GameObject snowball = Instantiate(snowPrefab, transform.position, Quaternion.identity);
            snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(snowVelocityinXdirectionLeftAndRight, snowVelocityinYdirectionLeftAndRight);
            Destroy(snowball, snowDisappear);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isLeft)
            {
            GameObject snowball = Instantiate(snowPrefab, transform.position, Quaternion.identity);
            snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(snowVelocityinXdirectionLeftAndRight * -1f, snowVelocityinYdirectionLeftAndRight);
            Destroy(snowball, snowDisappear);
        }
        //Throwing a snowball either up or down
        if(verticalDirection > 0f)
        {
            isRight = false;
            isLeft = false;
            isUp = true;
            isDown = false;
        }
        if (verticalDirection < 0f)
        {
            isRight = false;
            isLeft = false;
            isUp = false;
            isDown = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isUp)
        {
            GameObject snowballUpAndDown = Instantiate(snowPrefabUpandDown, transform.position, Quaternion.identity);
            snowballUpAndDown.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, snowVelocityinUpandDown);
            Destroy(snowballUpAndDown, snowDisappear);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDown)
        {
            GameObject snowballUpAndDown = Instantiate(snowPrefabUpandDown, transform.position, Quaternion.identity);
            snowballUpAndDown.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, snowVelocityinUpandDown * -1f);
            Destroy(snowballUpAndDown, snowDisappear);
        }

    }
}
