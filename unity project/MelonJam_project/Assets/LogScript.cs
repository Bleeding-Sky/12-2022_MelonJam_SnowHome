using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public Animator logAnimator;
    SpriteRenderer sr;
    public GameObject SnowMan;
    public GameObject Log;
    public bool isVisible = true;
    // Start is called before the first frame update
    void Start()
    {
       sr = SnowMan.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isVisible == false)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);

            Invoke("Visible", 3.25f);
            SnowMan.transform.position = new Vector2(Log.transform.position.x, Log.transform.position.y + .3f);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
            isVisible = true;
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Going through the pipe!");
            Invoke("GoUpLog", .05f);
            
    }
    


    public void GoUpLog()
    {
        logAnimator.SetBool("GoUp", true);
        isVisible = false;
        SnowMan.transform.position = new Vector2(Log.transform.position.x, Log.transform.position.y + .3f);
    }
    public void Visible()
    {
        isVisible = true;
        logAnimator.SetBool("GoUp", false);
    }
}




