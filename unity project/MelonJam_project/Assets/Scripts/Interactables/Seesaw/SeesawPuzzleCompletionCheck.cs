using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawPuzzleCompletionCheck : MonoBehaviour
{
    public bool seesawReady;
    public GameObject seesaw;
    BoxCollider2D interactableField;
    bool isInteractable;
    public GameObject hatTree;
    public Sprite noHatTreeSprite;

    // Start is called before the first frame update
    void Start()
    {
        seesawReady = false;
        seesaw = GameObject.FindGameObjectWithTag("Seesaw");
        interactableField = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if seesaw is filled with snow
        if (seesaw.GetComponent<InteractableStateHandler>().objectState == 2)
        {
            seesawReady= true;
        }
        else
        {
            seesawReady= false;
        }

        if (seesawReady)
        {
            tag = "Seesaw";
        }
        else
        {
            tag = string.Empty;
        }

        if (isInteractable)
        {
            if (Input.GetKeyDown("e"))
            {
                hatTree.GetComponent<SpriteRenderer>().sprite = noHatTreeSprite;
                GameObject.FindGameObjectWithTag("Player").GetComponent<ClothingHandler>().hasHat = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if seesaw is ready and snowfella is in the trigger
        if (seesawReady && collision.gameObject.CompareTag("Player"))
        {
            isInteractable= true;
            
        }
        //if seesaw is not ready and snowfella is in the trigger
        else if (!seesawReady && collision.gameObject.CompareTag("Player"))
        {
            seesaw.GetComponent<InteractableStateHandler>().objectState = 4;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if snowman leaves trigger, become uninteractable
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteractable= false;
        }
    }

}
