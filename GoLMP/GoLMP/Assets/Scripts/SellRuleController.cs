﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellRuleController : MonoBehaviour {

    private GameObject GG;

    public string _tag;

    private int place;

    public int Layer;

    private bool active = true;

    public Material[] NotAlive;

    public Material[] Alive;

    private void Start()
    {
        place = Mathf.RoundToInt(transform.position.x * 10.0f + -1 * transform.position.y * 100.0f + transform.position.z * 1000.0f);
        GG = GameObject.Find("GlobalGod");
        Layer = GG.GetComponent<GlobalGod>().Layers;
        _tag = transform.gameObject.tag;
    }

    private void Disable()
    {
        gameObject.layer = 8;
        GetComponent<BoxCollider>().enabled = false;
        active = false;
    }

    private void Enable()
    {
        gameObject.layer = 0;
        GetComponent<BoxCollider>().enabled = true;
        active = true;
    }

    private void Plus()
    {
        float Sp = ((GG.GetComponent<GlobalGod>().LayersNum) + GG.GetComponent<GlobalGod>().Layers - 1) / 10.0f;

        float bp = (GG.GetComponent<GlobalGod>().LayersNum - GG.GetComponent<GlobalGod>().Layers) / 10.0f;
        
        if (transform.position.z == bp & transform.position.x >= bp & transform.position.y <= -bp)
        {
            if (transform.position.x <= Sp & transform.position.y >= -Sp)
            {
                Enable();
            }
        }

        if (transform.position.y == -bp & transform.position.z >= bp & transform.position.x >= bp)
        {
            if (transform.position.x <= Sp & transform.position.z <= Sp)
            {
                Enable();
            }
        }

        if (transform.position.x == bp & transform.position.z >= bp & transform.position.y <= -bp)
        {
            if (transform.position.z <= Sp & transform.position.y >= -Sp)
            {
                Enable();
            }
        }


        if (transform.position.z == Sp & transform.position.x <= Sp & transform.position.y >= -Sp)
        {
            if (transform.position.x >= bp & transform.position.y <= -bp)
            {
                Enable();
            }
        }

        if (transform.position.y == -Sp & transform.position.x <= Sp & transform.position.z <= Sp)
        {
            if (transform.position.x >= bp & transform.position.z >= bp)
            {
                Enable();
            }
        }

        if (transform.position.x == Sp & transform.position.z <= Sp & transform.position.y >= -Sp)
        {
            if (transform.position.z >= bp & transform.position.y <= -bp)
            {
                Enable();
            }
        }
    }


private void Minus()
    {
        float S = ((GG.GetComponent<GlobalGod>().LayersNum) + GG.GetComponent<GlobalGod>().Layers) / 10.0f;

        float b = (GG.GetComponent<GlobalGod>().LayersNum - GG.GetComponent<GlobalGod>().Layers - 1) / 10.0f;

        if (transform.position.x == b)
        {
            Disable();
        }

        if (transform.position.y == -b)
        {
            Disable();
        }

        if (transform.position.z == b)
        {
            Disable();
        }

        if (transform.position.x == S)
        {
            Disable();
        }

        if (transform.position.y == -S)
        {
            Disable();
        }

        if (transform.position.z == S)
        {
            Disable();
        }
    }

    private void ChangeStatus(int Status)
    {
        GG.GetComponent<GlobalGod>().SellArray[place] = Status;
        if (Status == 0)
        {
            transform.gameObject.tag = "NonAlive";
        }
        else
        {
            if (Status == 1)
            {
                transform.gameObject.tag = "Alive";
            }
        }
    }

    private void OnMouseOver()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0) & GG.GetComponent<GlobalGod>().begin != true & transform.gameObject.tag == "NonAlive")
            {
                ChangeStatus(1);
            }
            else
            {
                if (Input.GetMouseButtonDown(0) & GG.GetComponent<GlobalGod>().begin != true & transform.gameObject.tag == "Alive")
                {
                    ChangeStatus(0);
                }
            }
        }
    }

    public void DoMove()
    {
        if (!GetComponent<mousecntr>().Selected)
        {
            if (GG.GetComponent<GlobalGod>().SellArray[place] == 1)
            {
                for (int i = 0;i < Alive.Length; i++)
                    GetComponentsInChildren<Renderer>()[i].material = Alive[i];
            }
            else
            {
                for (int i = 0; i < NotAlive.Length; i++)
                    GetComponentsInChildren<Renderer>()[i].material = NotAlive[i];
            }
        }
        if (GG.GetComponent<GlobalGod>().SellArray[place] == -1)
        {
            GetComponent<mousecntr>().enabled = false;
            this.enabled = false;
        }
    }

    void Update ()
    {
        DoMove();
        if (Layer < GG.GetComponent<GlobalGod>().Layers)
        {
            Plus();
            Layer = GG.GetComponent<GlobalGod>().Layers;
        }

        if (Layer > GG.GetComponent<GlobalGod>().Layers)
        {
            Minus();
            Layer = GG.GetComponent<GlobalGod>().Layers;
        }
    }
}
