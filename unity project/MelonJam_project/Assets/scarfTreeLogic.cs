using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarfTreeLogic : MonoBehaviour
{
    public Sprite noScarfTree;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnowBall"))
        {
            GetComponent<SpriteRenderer>().sprite = noScarfTree;
            GetComponentInChildren<CircleCollider2D>().enabled= true;
        }

    }

}
