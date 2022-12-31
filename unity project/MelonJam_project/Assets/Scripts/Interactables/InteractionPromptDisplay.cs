using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPromptDisplay : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //stay right above player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .25f, 0);

        if (player.GetComponent<PlaceSnowInteraction>().isInInteractableRange)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
        }
    }
}
