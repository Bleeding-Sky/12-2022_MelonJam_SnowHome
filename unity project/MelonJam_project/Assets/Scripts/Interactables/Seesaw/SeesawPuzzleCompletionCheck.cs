using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawPuzzleCompletionCheck : MonoBehaviour
{
    public bool seesawReady;

    // Start is called before the first frame update
    void Start()
    {
        seesawReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if seesaw is filled with snow
        if (GameObject.FindGameObjectWithTag("Seesaw").GetComponent<InteractableStateHandler>().objectState == 2)
        {
            seesawReady= true;
        }
        else
        {
            seesawReady= false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (seesawReady && collision.gameObject.CompareTag("SnowFella"))
        {
            if (Input.GetKeyDown("e"))
            {
                collision.gameObject.GetComponent<ClothingHandler>().hasHat = true;
            }
        }
    }
}
