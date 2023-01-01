using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOve : MonoBehaviour
{
    public Camera MainCamera;
    
    public bool cameraMove;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        cameraMove = false;
        Invoke("StartMoving", 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMove == true)
        {
            MainCamera.transform.position = Vector3.Lerp(transform.position, new Vector3(0.1260303f, 6.382957f, -10), speed * Time.deltaTime);
            Invoke("StopMoving", 4);
        }
    }

    public void StartMoving()
    {
        cameraMove = true;
    }
    public void StopMoving()
    {
        cameraMove = false;
        MainCamera.transform.position = new Vector3(0.1260303f, 6.382957f, -10);
    }
}
