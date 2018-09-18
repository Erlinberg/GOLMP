using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGroupsController : MonoBehaviour{

    public float speed = 30.0f;



    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if ((Mathf.Abs(Input.GetAxis("Mouse X"))) > (Mathf.Abs(Input.GetAxis("Mouse Y"))))
            {
                transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            }

            else
            {
                transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f, Space.World);
            }
        }
    }
}
