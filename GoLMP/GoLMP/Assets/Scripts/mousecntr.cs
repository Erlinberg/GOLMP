using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecntr : MonoBehaviour {

    public Material Select;

    public bool Selected = false;

    private void OnMouseEnter()
    {
        Selected = true;
        //if (GetComponent<SellRuleController>.)
        //GetComponent<Renderer>().material = Select;
    }

    private void OnMouseExit()
    {  
        Selected = false;
    }
}
