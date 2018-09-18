using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour {

    private Vector3 MainCameraPosition;


    private Quaternion MainCameraRotate;



    void Start ()
    {
        MainCameraPosition = GetComponentInParent<Transform>().position;

        MainCameraRotate = GetComponentInParent<Transform>().rotation;
    }
	

	void Update ()
    {
        MainCameraPosition = GetComponentInParent<Transform>().position;
        MainCameraRotate = GetComponentInParent<Transform>().rotation;

        transform.position = MainCameraPosition;
        transform.rotation = MainCameraRotate;
    }
}
