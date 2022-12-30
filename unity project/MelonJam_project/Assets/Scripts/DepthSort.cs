using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DepthSort : MonoBehaviour
{
    [SerializeField]
    private float sortingOrderBase = 500;
    [SerializeField]
    private float offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;

    private float timer;
    private float timerMax = .1f;
    private Renderer myRenderer;


    // Update is called once per frame
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

   private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
