using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManMovement : MonoBehaviour
{
    public float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
       
        
        transform.position = transform.position + new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);
        
    }

    void FixedUpdate()
    {
        
    }
}
