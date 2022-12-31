using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableStateHandler : MonoBehaviour
{
    public int objectState;
    /*
     * 0 = no snow
     * 1 = a little snow
     * 2 = full of snow
     */

    // Start is called before the first frame update
    void Start()
    {
        objectState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
