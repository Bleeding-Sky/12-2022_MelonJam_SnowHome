using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS GOES ON THE SNOW FELLA
public class PlaceSnowInteraction : MonoBehaviour
{
    CircleCollider2D interactionRadius;
    InteractionPromptDisplay interactionPrompt;
    public bool isInInteractableRange;
    public GameObject currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        interactionRadius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInInteractableRange)
        {
            if (Input.GetKeyDown("e"))
            {
                currentInteractable.GetComponent<InteractableStateHandler>().objectState++;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D interactable)
    {
        if (interactable.CompareTag("Seesaw") || interactable.CompareTag("Gutter") || interactable.CompareTag("possessionTrigger"))
        {
            isInInteractableRange = true;
            currentInteractable = interactable.gameObject;

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        isInInteractableRange= false;

    }

}
