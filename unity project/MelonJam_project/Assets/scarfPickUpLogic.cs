using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarfPickUpLogic : MonoBehaviour
{

    bool playerInRange = false;
    GameObject player;
    public GameObject tree;
    public Sprite emptyTree;

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
                tree.GetComponent<SpriteRenderer>().sprite = emptyTree;
                player.GetComponent<ClothingHandler>().hasScarf= true;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange= true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange= false;
    }

}
