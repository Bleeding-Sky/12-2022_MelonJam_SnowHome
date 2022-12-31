using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSnowInteraction : MonoBehaviour
{
    CircleCollider2D interactionRadius;

    // Start is called before the first frame update
    void Start()
    {
        interactionRadius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
