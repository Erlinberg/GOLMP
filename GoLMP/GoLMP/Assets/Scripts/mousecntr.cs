using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecntr : MonoBehaviour {

    public Material Select;

    public bool Selected = false;

    private void OnMouseEnter()
    {
        Selected = true;
        GetComponent<Renderer>().material = Select;
    }

    private void OnMouseExit()
    {
        if (GetComponent<SellRuleController>()._tag == "NotAlive")
        {
            GetComponent<Renderer>().material = GetComponent<SellRuleController>().NotAlive;
        }
        else
        {
            GetComponent<Renderer>().material = GetComponent<SellRuleController>().Alive;
        }
        Selected = false;
    }
}
