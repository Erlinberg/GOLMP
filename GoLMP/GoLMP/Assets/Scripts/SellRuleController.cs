using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellRuleController : MonoBehaviour {

    public Mesh[] activemeshes;

    public Mesh[] nonactivemeshes;


    public Material[] NotAlive;

    public Material[] Alive;



    private int CellID;

    public int CellCurrentLayer;

    public int Style = 0;



    private bool Changed = false;

    private bool Active = true;



    private GameObject GameController;



    public Material mtr;



    private void DisableCell()
    {
        gameObject.layer = 8;

        foreach (Transform child in transform)
        {
            child.gameObject.layer = 8;
        }

        GetComponent<BoxCollider>().enabled = false;

        Active = false;
    }

    private void EnableCell()
    {
        gameObject.layer = 0;

        foreach (Transform child in transform)
        {
            child.gameObject.layer = 0;
        }

        GetComponent<BoxCollider>().enabled = true;

        Active = true;
    }

    private void ChangeLayer()
    {
        if ((transform.parent.name == ("Layer " + (GameController.GetComponent<GlobalGod>().CurrentLayers - 1) + "(Clone)")))
        {
            EnableCell();
        }

        else
        {
            DisableCell();
        }

        //float Sp = ((GameController.GetComponent<GlobalGod>().LayersNum) + GameController.GetComponent<GlobalGod>().Layers - 1) / 10.0f;

        //float bp = (GameController.GetComponent<GlobalGod>().LayersNum - GameController.GetComponent<GlobalGod>().Layers) / 10.0f;
        
        //if (transform.position.z == bp & transform.position.x >= bp & transform.position.y <= -bp)
        //{
        //    if (transform.position.x <= Sp & transform.position.y >= -Sp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}

        //if (transform.position.y == -bp & transform.position.z >= bp & transform.position.x >= bp)
        //{
        //    if (transform.position.x <= Sp & transform.position.z <= Sp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}

        //if (transform.position.x == bp & transform.position.z >= bp & transform.position.y <= -bp)
        //{
        //    if (transform.position.z <= Sp & transform.position.y >= -Sp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}


        //if (transform.position.z == Sp & transform.position.x <= Sp & transform.position.y >= -Sp)
        //{
        //    if (transform.position.x >= bp & transform.position.y <= -bp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}

        //if (transform.position.y == -Sp & transform.position.x <= Sp & transform.position.z <= Sp)
        //{
        //    if (transform.position.x >= bp & transform.position.z >= bp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}

        //if (transform.position.x == Sp & transform.position.z <= Sp & transform.position.y >= -Sp)
        //{
        //    if (transform.position.z >= bp & transform.position.y <= -bp)
        //    {
        //        Enable();
        //        changed = true;
        //    }
        //}

        //if (!changed & transform.gameObject.tag == "NonAlive")
        //{
        //    Disable();
        //    changed = false;
        //}

        //if (!changed & transform.gameObject.tag == "Alive")
        //{
        //    GetComponent<BoxCollider>().enabled = false;
        //    changed = false;
        //}

        //changed = false;
    }

    private void ChangeStatus(int Status)
    {
        GameController.GetComponent<GlobalGod>().MainCellArray[CellID] = Status;
        if (Status == 0)
        {
            transform.gameObject.tag = "NonAlive";
        }

        else if (Status == 1)
        {
            transform.gameObject.tag = "Alive";
        }
    }

    public void DoStep()
    {
        if (!GetComponent<mousecntr>().Selected)
        {
            if (GameController.GetComponent<GlobalGod>().MainCellArray[CellID] == 1)
            {
                for (int materialID = 0; materialID < Alive.Length; materialID++)
                {
                    GetComponentsInChildren<Renderer>()[materialID].material = Alive[materialID];
                    GetComponentsInChildren<MeshFilter>()[materialID].mesh = activemeshes[materialID];
                }


                transform.gameObject.layer = 9;

                foreach (Transform child in transform)
                {
                    child.gameObject.layer = 9;
                }


                if (Style == 1)
                {
                    GetComponent<Renderer>().material = Alive[0];
                }

                if (Style == 2)
                {
                    GetComponent<Renderer>().material = mtr;
                }

            }

            else
            {
                for (int meshID = 0; meshID < NotAlive.Length; meshID++)
                {
                    GetComponentsInChildren<Renderer>()[meshID].material = NotAlive[meshID];
                    GetComponentsInChildren<MeshFilter>()[meshID].mesh = nonactivemeshes[meshID];
                }
            }
        }

        if (GameController.GetComponent<GlobalGod>().MainCellArray[CellID] == -1)
        {
            GetComponent<mousecntr>().enabled = false;
            GetComponent<SellRuleController>().enabled = false;
        }
    }


    private void Start()
    {
        CellID = Mathf.RoundToInt(transform.position.x * 10.0f + -1 * transform.position.y * 100.0f + transform.position.z * 1000.0f);
        GameController = GameObject.Find("GlobalGod");
        CellCurrentLayer = GameController.GetComponent<GlobalGod>().CurrentLayers;
        ChangeLayer();
    }

    private void OnMouseOver()
    {
        if (Active)
        {
            if (Input.GetMouseButtonDown(0) & transform.gameObject.tag == "NonAlive")
            {
                ChangeStatus(1);
            }

            else if (Input.GetMouseButtonDown(0) & transform.gameObject.tag == "Alive")
            {
                ChangeStatus(0);
            }

            if (transform.gameObject.tag == "Alive")
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Style = 1;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Style = 2;
                }
            }
        }
    }

    void Update ()
    {
        DoStep();
        if (CellCurrentLayer != GameController.GetComponent<GlobalGod>().CurrentLayers)
        {
            ChangeLayer();
            CellCurrentLayer = GameController.GetComponent<GlobalGod>().CurrentLayers;
        }
    }
}
