using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSnowFallingScript : MonoBehaviour
{
    public Rigidbody2D SnowBall;
    public Animator treeAnimation;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("not hit!");
        }
        else
        {
            Debug.Log("TreeHit!");
            treeAnimation.SetInteger("TreeHit", 1);
        }
    }
}
