using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class flyingHeadLogic : MonoBehaviour
{
    public int direction;
    float moveSpeed = .04f;

    public GameObject player;
    public GameObject newLumpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //move based on direction
        if (direction == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
        }
        else if (direction == 1)
        {
            transform.position = new Vector3(transform.position.x+moveSpeed, transform.position.y, transform.position.z);
        }
        else if (direction == 2) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }
        else if (direction == 3)
        {
            transform.position = new Vector3(transform.position.x-moveSpeed, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("possessionLump"))
        {
            Debug.Log("collision");
            Vector3 oldPosition = player.transform.position;

            //move player to the spot of the collision
            player.transform.position = collision.gameObject.transform.position;

            //make player visible
            player.GetComponent<SpriteRenderer>().color = new Color(player.GetComponent<SpriteRenderer>().color.r, player.GetComponent<SpriteRenderer>().color.g, player.GetComponent<SpriteRenderer>().color.b, 1);

            Instantiate(newLumpPrefab, oldPosition, Quaternion.identity);


            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
