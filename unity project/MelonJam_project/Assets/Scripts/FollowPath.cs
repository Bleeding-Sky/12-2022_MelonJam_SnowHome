using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private float rollTime;

    public GameObject WayPoint1;
    public GameObject WayPoint2;
    public GameObject SnowFella;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("RollingTrigger"))
        {

            SnowFella.transform.position = WayPoint2.transform.position;
        }

    }
}