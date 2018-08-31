using System.Collections;
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

    private bool changed = false;

    private void Disable()
    {
        gameObject.layer = 8;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 8;
        }
        GetComponent<BoxCollider>().enabled = false;
        active = false;
    }

    private void Enable()
    {
        gameObject.layer = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 0;
        }
        GetComponent<BoxCollider>().enabled = true;
        active = true;
    }

    private void ChangeLayer()
    {
        float Sp = ((GG.GetComponent<GlobalGod>().LayersNum) + GG.GetComponent<GlobalGod>().Layers - 1) / 10.0f;

        float bp = (GG.GetComponent<GlobalGod>().LayersNum - GG.GetComponent<GlobalGod>().Layers) / 10.0f;
        
        if (transform.position.z == bp & transform.position.x >= bp & transform.position.y <= -bp)
        {
            if (transform.position.x <= Sp & transform.position.y >= -Sp)
            {
                Enable();
                changed = true;
            }
        }

        if (transform.position.y == -bp & transform.position.z >= bp & transform.position.x >= bp)
        {
            if (transform.position.x <= Sp & transform.position.z <= Sp)
            {
                Enable();
                changed = true;
            }
        }

        if (transform.position.x == bp & transform.position.z >= bp & transform.position.y <= -bp)
        {
            if (transform.position.z <= Sp & transform.position.y >= -Sp)
            {
                Enable();
                changed = true;
            }
        }


        if (transform.position.z == Sp & transform.position.x <= Sp & transform.position.y >= -Sp)
        {
            if (transform.position.x >= bp & transform.position.y <= -bp)
            {
                Enable();
                changed = true;
            }
        }

        if (transform.position.y == -Sp & transform.position.x <= Sp & transform.position.z <= Sp)
        {
            if (transform.position.x >= bp & transform.position.z >= bp)
            {
                Enable();
                changed = true;
            }
        }

        if (transform.position.x == Sp & transform.position.z <= Sp & transform.position.y >= -Sp)
        {
            if (transform.position.z >= bp & transform.position.y <= -bp)
            {
                Enable();
                changed = true;
            }
        }

        if (!changed & transform.gameObject.tag == "NonAlive")
        {
            Disable();
            changed = false;
        }

        if (!changed & transform.gameObject.tag == "Alive")
        {
            GetComponent<BoxCollider>().enabled = false;
            changed = false;
        }

        changed = false;
    }

    private void Start()
    {
        place = Mathf.RoundToInt(transform.position.x * 10.0f + -1 * transform.position.y * 200.0f + transform.position.z * 4000.0f);
        GG = GameObject.Find("GlobalGod");
        Layer = GG.GetComponent<GlobalGod>().Layers;
        _tag = transform.gameObject.tag;
        ChangeLayer();
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
                if (active)
                {
                    transform.gameObject.layer = 9;
                    foreach (Transform child in transform)
                        child.gameObject.layer = 9;
                }
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
            GetComponent<SellRuleController>().enabled = false;
        }
    }

    void Update ()
    {
        DoMove();
        if (Layer != GG.GetComponent<GlobalGod>().Layers)
        {
            ChangeLayer();
            Layer = GG.GetComponent<GlobalGod>().Layers;
        }
    }
}
