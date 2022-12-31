using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawLogic : MonoBehaviour
{
    InteractableStateHandler stateHandler;
    // Start is called before the first frame update
    void Start()
    {
        stateHandler= GetComponent<InteractableStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //if full of snow and interacted with, stay full of snow
        if (stateHandler.objectState >= 2)
        {
            stateHandler.objectState = 2;
            gameObject.GetComponent<CapsuleCollider2D>().enabled= false;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled= true;
        }
    }

    
}
