using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDownScript : MonoBehaviour
{
    public Animator logAnimator;
    public SpriteRenderer sprite;
    public GameObject SnowMan;
    public GameObject Log;
    public bool isVisible = true;
    // Start is called before the first frame update
    void Start()
    {
        sprite = SnowMan.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible == false)
        {
            
            Invoke("Visible", 3.875f);

            //Debug.Log("invoking visible");
            SnowMan.transform.position = new Vector2(Log.transform.position.x - .012f, Log.transform.position.y - .365f);
        }
        else 
        {
            SnowMan.GetComponent<SpriteRenderer>().color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            Debug.Log("snow is now visible");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Going through the pipe!");
        GoDownLog();
      
    }


    public void GoDownLog()
    {
        logAnimator.SetBool("GoDown", true);
        isVisible = false;
        Debug.Log("snow should be invisible");
        SnowMan.GetComponent<SpriteRenderer>().color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        Debug.Log("Snowman is invisible");
        SnowMan.transform.position = new Vector2(Log.transform.position.x -.012f, Log.transform.position.y - .365f);
    }
    public void Visible()
    {
        
        isVisible = true;
        logAnimator.SetBool("GoDown", false);
    }
}
