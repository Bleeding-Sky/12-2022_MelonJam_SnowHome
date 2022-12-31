using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS GOES ON THE SNOW FELLA
public class PlaceSnowInteraction : MonoBehaviour
{
    CircleCollider2D interactionRadius;
    InteractionPromptDisplay interactionPrompt;
    public bool isInInteractableRange;

    // Start is called before the first frame update
    void Start()
    {
        interactionRadius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D interactable)
    {
        isInInteractableRange = true;

        if (Input.GetKeyDown("e"))
        {
            interactable.gameObject.GetComponent<InteractableStateHandler>().objectState++;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        isInInteractableRange= false;

    }

}
