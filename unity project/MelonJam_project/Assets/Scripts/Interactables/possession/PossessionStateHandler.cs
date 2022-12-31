using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionStateHandler : MonoBehaviour
{
    public int objectState;
    public GameObject possessionTargetObject;
    public GameObject player;
    public GameObject newLumpPrefab;
    public GameObject flyingHeadPrefab;
    public bool triggered = false;
    /*
     * 0 = no snow
     * 1 = a little snow
     * 2 = full of snow
     */

    // Start is called before the first frame update
    void Start()
    {
        newLumpPrefab = GameObject.FindGameObjectWithTag("possessionLump");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        objectState = GetComponent<InteractableStateHandler>().objectState;
        if (objectState != 0 && !triggered)
        {
            //make player invisible
            player.GetComponent<SpriteRenderer>().color = new Color(player.GetComponent<SpriteRenderer>().color.r, player.GetComponent<SpriteRenderer>().color.g, player.GetComponent<SpriteRenderer>().color.b, 0);

            //create new snowLump at player condition
            //Instantiate(newLumpPrefab, player.transform.position, Quaternion.identity);

            //create flying head
            GameObject flyingHead = Instantiate(flyingHeadPrefab, player.transform.position, Quaternion.identity);
            Debug.Log("flying head created");

            //set flying head movement direction
            if (name == "upInteract")
            {
                flyingHead.GetComponent<flyingHeadLogic>().direction = 2;
            }
            else if (name == "downInteract")
            {
                flyingHead.GetComponent<flyingHeadLogic>().direction = 0;
            }
            else if (name == "leftInteract")
            {
                flyingHead.GetComponent<flyingHeadLogic>().direction = 1;
            }
            else if (name == "rightInteract")
            {
                flyingHead.GetComponent<flyingHeadLogic>().direction = 3;
            }

            triggered = true;

        }
    }
}
