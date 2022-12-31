using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawLogic : MonoBehaviour
{
    InteractableStateHandler stateHandler;
    SpriteRenderer spriteRenderer;

    public Sprite noSnow;
    public Sprite snow;
    public Sprite lotsOfSnow;
    public Sprite leftDown;
    bool resetInProgress;
    float resetTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        stateHandler= GetComponent<InteractableStateHandler>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        resetInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if full of snow and interacted with, stay full of snow
        if (stateHandler.objectState == 3 || stateHandler.objectState == 2)
        {
            stateHandler.objectState = 2;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }

        setSprite();

        //reset seesaw if puzzle failed
        if (stateHandler.objectState == 4)
        {
            if (!resetInProgress)
            {
                resetInProgress= true;
                GameObject player = GameObject.FindGameObjectWithTag("SnowFella");
                player.transform.position = new Vector3(player.transform.position.x - .2f,
                    player.transform.position.y - .1f, player.transform.position.z);
            }
            else
            {
                resetTimer += Time.deltaTime;
                if (resetTimer >= 1.5)
                {
                    resetInProgress= false;
                    resetTimer = 0;
                    stateHandler.objectState = 0;
                }
            }
        }

    }

    private void setSprite()
    {
        //change sprite based on state
        if (stateHandler.objectState == 0)
        {
            spriteRenderer.sprite = noSnow;
        }
        else if (stateHandler.objectState == 1)
        {
            spriteRenderer.sprite = snow;
        }
        else if (stateHandler.objectState == 2)
        {
            spriteRenderer.sprite = lotsOfSnow;
        }
        else if (stateHandler.objectState == 4)
        {
            spriteRenderer.sprite = leftDown;
        }
    }

}
