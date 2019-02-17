using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject followTarget;
    public float cameraSpeed;
    private Vector3 targetPos;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Z-Axis unchanged as it should remain the camera's default -10; cameraSpeed is adjusted by the deltaTime
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        //targetPos = followTarget.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeed * Time.deltaTime);
        
	}
}
