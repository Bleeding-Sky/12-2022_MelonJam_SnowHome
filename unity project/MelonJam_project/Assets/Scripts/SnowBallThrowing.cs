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
    public bool isNotMoving = true;
    public float SnowBallCount;
    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        isLeft = false;
        isUp = false;
        isDown = false;
        SnowBallCount = 2;
    }

    // Update is called once per frame
    void Update()
    {

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

        if (Input.GetKeyDown(KeyCode.X))
        {

            if (SnowBallCount <= 10)
            {
                if(SnowBallCount%2==0)
                {
                    SnowBallCount = SnowBallCount + 2;
                    Debug.Log(SnowBallCount);
                }
                else
                {
                    SnowBallCount = SnowBallCount + 3;
                    Debug.Log(SnowBallCount);
                }
            }
            else
            {
                SnowBallCount = 10;
            }
            Debug.Log(SnowBallCount);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SnowBallCount > 2)
            {
                SnowBallCount = SnowBallCount - 1;
            }
            else
            {
                SnowBallCount = 2;
            }
            Debug.Log(SnowBallCount);
        }
            //Throwing a snowball either left or right
            if (horizontalDirection > 0f)
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
        if (Input.GetKeyDown(KeyCode.Space) && isRight && isNotMoving && SnowBallCount > 2)
        {
            GameObject snowball = Instantiate(snowPrefab, transform.position, Quaternion.identity);
            snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(snowVelocityinXdirectionLeftAndRight, snowVelocityinYdirectionLeftAndRight);
            snowball.GetComponent<DepthDortSnowBall>().initialYLocation = transform.position.y;
            Destroy(snowball, snowDisappear);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isLeft && isNotMoving && SnowBallCount > 2)
            {
            GameObject snowball = Instantiate(snowPrefab, transform.position, Quaternion.identity);
            snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(snowVelocityinXdirectionLeftAndRight * -1f, snowVelocityinYdirectionLeftAndRight);
            snowball.GetComponent<DepthDortSnowBall>().initialYLocation = transform.position.y;
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
        if (Input.GetKeyDown(KeyCode.Space) && isUp && isNotMoving && SnowBallCount > 2)
        {
            GameObject snowballUpAndDown = Instantiate(snowPrefabUpandDown, transform.position, Quaternion.identity);
            snowballUpAndDown.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, snowVelocityinUpandDown);
            snowballUpAndDown.GetComponent<SnowballLogic>().throwTimer = snowDisappear;
            snowballUpAndDown.GetComponent<DepthDortSnowBall>().initialYLocation = transform.position.y;
            //Destroy(snowballUpAndDown, snowDisappear);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDown && isNotMoving && SnowBallCount > 2)
        {
            GameObject snowballUpAndDown = Instantiate(snowPrefabUpandDown, transform.position, Quaternion.identity);
            snowballUpAndDown.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, snowVelocityinUpandDown * -1f);
            snowballUpAndDown.GetComponent<SnowballLogic>().throwTimer = snowDisappear;
            snowballUpAndDown.GetComponent<DepthDortSnowBall>().initialYLocation = transform.position.y;
            //Destroy(snowballUpAndDown, snowDisappear);
        }

    }
}
