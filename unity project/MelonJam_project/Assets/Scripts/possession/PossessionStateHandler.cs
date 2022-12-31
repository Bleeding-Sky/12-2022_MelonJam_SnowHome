using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionStateHandler : MonoBehaviour
{
    public int objectState;
    public GameObject possessionTargetObject;
    public GameObject player;
    /*
     * 0 = no snow
     * 1 = a little snow
     * 2 = full of snow
     */

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        objectState = GetComponent<InteractableStateHandler>().objectState;
        if (objectState != 0)
        {
            Debug.Log("moving player and making invisible");
            player.transform.position = possessionTargetObject.transform.position;
            player.GetComponent<SpriteRenderer>().color = new Color(player.GetComponent<SpriteRenderer>().color.r, player.GetComponent<SpriteRenderer>().color.g, player.GetComponent<SpriteRenderer>().color.b, 0);
        }
    }
}
