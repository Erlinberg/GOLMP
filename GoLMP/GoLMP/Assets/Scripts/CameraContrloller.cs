using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrloller : MonoBehaviour
{
    float rotSpeed = 20;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }


    // 2nd try


    //public float sensitivity = 3; // чувствительность мышки

    //private bool IsLayerActive;

    //public int LayerOn;

    //private float X, Y;

    //void Start()
    //{
    //    IsLayerActive = (LayerOn == GameObject.Find("GlobalGod").GetComponent<GlobalGod>().Layers - 1);
    //}

    //void Update()
    //{
    //    if (IsLayerActive)
    //    {
    //        if (Input.GetMouseButton(1))
    //        {
    //            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sensitivity);
    //        }
    //        transform.localEulerAngles = new Vector3(-X, Y, 0);
    //    }
    //}


    // 1st try


    //[SerializeField]
    //public Transform target;

    //public Vector3 offset;

    //public float sensitivity = 3; // чувствительность мышки

    //public float limit = 80; // ограничение вращения по Y

    //public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки

    //public float zoomMax = 10; // макс. увеличение

    //public float zoomMin = 3; // мин. увеличение

    //private float X, Y;

    //void Start()
    //{
    //    limit = Mathf.Abs(limit);
    //    if (limit > 90) limit = 90;
    //    offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
    //    transform.position = target.position + offset;
    //}

    //void Update()
    //{
    //    if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
    //    else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
    //    offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

    //    if (Input.GetMouseButton(1))
    //    {
    //        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
    //        Y += Input.GetAxis("Mouse Y") * sensitivity;
    //        Y = Mathf.Clamp(Y, -limit, limit);
    //    }
    //    transform.localEulerAngles = new Vector3(-Y, X, 0);
    //    transform.position = transform.localRotation * offset + target.position;
    //}
}
