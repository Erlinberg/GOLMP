using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecntr : MonoBehaviour {

    public Material Select;



    public bool Selected = false;



    private void OnMouseEnter()
    {
        Selected = true;

        if (GetComponent<SellRuleController>().enabled)
        {
            if (GetComponent<SellRuleController>().NotAlive.Length > 1)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.GetComponent<Renderer>().material = Select;
                }
            }

            else
            {
                transform.gameObject.GetComponent<Renderer>().material = Select;
            }
        }
    }

    private void OnMouseExit()
    {  
        Selected = false;
    }
}
