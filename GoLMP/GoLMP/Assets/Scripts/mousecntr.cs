using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecntr : MonoBehaviour {

    private Color M;

    private void OnMouseEnter()
    {
        M = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        if (GetComponent<Renderer>().material.color != Color.green)
        {
            GetComponent<Renderer>().material.color = M;
        }
    }
}
