using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour {

    private Vector3 MainCameraPosition;

    private Quaternion MainCameraRotate;

    // Use this for initialization
    void Start ()
    {
        MainCameraPosition = GetComponentInParent<Transform>().position;
        MainCameraRotate = GetComponentInParent<Transform>().rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MainCameraPosition = GetComponentInParent<Transform>().position;
        MainCameraRotate = GetComponentInParent<Transform>().rotation;

        transform.position = MainCameraPosition;
        transform.rotation = MainCameraRotate;

    }
}
