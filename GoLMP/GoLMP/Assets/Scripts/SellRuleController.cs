using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellRuleController : MonoBehaviour {

    private GameObject GG;

    private string _tag;

    private int move = 1;

    private int place;

    private int num = 0;


    private void Start()
    {
        place = Mathf.RoundToInt(transform.position.x * 10.0f + -1 * transform.position.y * 100.0f + transform.position.z * 1000.0f);
        GG = GameObject.Find("GlobalGod");
    }

    private void ChangeStatus(int Status)
    {
        GG.GetComponent<GlobalGod>().SellArray[place] = Status;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) & GG.GetComponent<GlobalGod>().begin != true)
        {
            ChangeStatus(1);
        }
    }

    public void DoMove()
    {
        if (GG.GetComponent<GlobalGod>().SellArray[place] == 1)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    void Update ()
    {
        DoMove();
    }
}
