using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipePickUpLogic : MonoBehaviour
{

    bool playerInRange = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKey("e"))
            {
                GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
                player.GetComponent<ClothingHandler>().hasPipe = true;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }

}
