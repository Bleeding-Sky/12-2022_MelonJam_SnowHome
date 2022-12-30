using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballLogic : MonoBehaviour
{
    public float throwTimer;
    public float currentTimer = 0;
    new Rigidbody2D rigidbody2D;
    Vector3 originalScale;


    //TODO: move destroy code in here + change size on up/down throws

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalScale= transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;

        //up/down size change in air
        if (rigidbody2D.velocity.y != 0)
        {
            if (currentTimer <= .2)
            {
                //leave at default scale
            }
            else if (currentTimer <= .4 * throwTimer)
            {
                gameObject.transform.localScale = originalScale * 1.3f;
            }
            else if (currentTimer < .6 * throwTimer)
            {
                gameObject.transform.localScale = originalScale * 1.6f;
            }
            else if (currentTimer < .8 * throwTimer)
            {
                gameObject.transform.localScale = originalScale * 1.1f;
            }
            else if (currentTimer < throwTimer)
            {
                gameObject.transform.localScale = originalScale * .7f;
            }
        }

        //destroy snowball when timer expires
        if (currentTimer >= throwTimer )
        {
            Destroy(gameObject);
        }
    }
}
