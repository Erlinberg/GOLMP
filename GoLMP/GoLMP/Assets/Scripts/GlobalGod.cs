using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalGod : MonoBehaviour
{
    public class Cell
    {
        public int x;
        public int y;
        public int z;
    }

    public Cell[] CellParametersArray;


    public string[] NameListOfModels;


    public int[] MainCellArray;

    public int[] ChangedCellArray;

    private int[] Delta = new int[3];

    // MD is meaning Multi - Dimentional(This one is two dimentional) Array
    private List<List<Transform>> LayersMDArray = new List<List<Transform>>();



    public int FieldSize;

    public int OverPopulation;

    public int UnderPopulation;

    public int NewLife;

    public int AllLayersNumber;

    public int CurrentLayers;

    private int NumberOfCollidedAliveCells = 0;

    public int AllTime = 2;


    private float TimeLeft = 2;


    public bool BeginSimulation = false;


    private void WriteFunction(string text)
    {
        if (!Directory.Exists("Settings"))
        {
            Directory.CreateDirectory("Settings");
        }


        if (!File.Exists("Settings/settings.ini"))
        {
            File.Create("Settings/settings.ini");
        }


        File.AppendAllText("Settings/settings.ini", Time.time.ToString() + ':' + text + '\n');
    }

    private int GetID(int collidedObjectX, int collidedObjectY, int collidedObjectZ)
    {
        return collidedObjectZ * (FieldSize * FieldSize) + collidedObjectY * FieldSize + collidedObjectX;
    }

    private int InField(int deltaX, int deltaY, int deltaZ, int id)
    {
        int collidedObjectX = CellParametersArray[id].x + deltaX;

        int collidedObjectY = CellParametersArray[id].y + deltaY;

        int collidedObjectZ = CellParametersArray[id].z + deltaZ;

        if (deltaX == 0 & deltaY == 0 & deltaZ == 0)
        {
            return 0;
        }

        else if ((collidedObjectX < 0) || (collidedObjectX > FieldSize - 1))
        {
            return 0;
        }

        else if ((collidedObjectY < 0) || (collidedObjectY > FieldSize - 1))
        {
            return 0;
        }

        else if ((collidedObjectZ < 0) || (collidedObjectZ > FieldSize - 1))
        {
            return 0;
        }

        else
        {
            return MainCellArray[GetID(collidedObjectX, collidedObjectY, collidedObjectZ)];
        }
    }

    private void SumAround(int id)
    {
        NumberOfCollidedAliveCells = 0;
        Delta[0] = -1;
        Delta[1] = 0;
        Delta[2] = 1;
        foreach (int deltaX in Delta)
            foreach (int deltaY in Delta)
                foreach (int deltaZ in Delta)
                {
                    NumberOfCollidedAliveCells += InField(deltaX, deltaY, deltaZ, id);
                }
    }



    private void CreateLayerPrefab()
    {
        int Layer = 0;
        for (int z = 0; z < FieldSize; z++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                for (int x = 0; x < FieldSize; x++)
                {

                    LayersMDArray[Layer].Add(Instantiate(Resources.Load("GameCells/Cube"), new Vector3(x / 10.0f, (y / 10.0f) * -1, z / 10.0f), Quaternion.identity) as Transform);

                }
            }
        }
    }

    private void CreateField()
    {
        foreach (Transform obj in LayersMDArray[AllLayersNumber - CurrentLayers])
        {
            obj.gameObject.SetActive(true);
        }
    }

    private void DeleteAllCubes()
    {
        for(int i = 0;i < FieldSize * FieldSize * FieldSize; i++)
        {
            MainCellArray[i] = -1;
        }
    }

    private void CheckOneStep()
    {
        for (int id = 0; id < Mathf.Pow(FieldSize, 3); id++)
        {
            SumAround(id);

            if (MainCellArray[id] == 1)
            {
                if ((NumberOfCollidedAliveCells > UnderPopulation) || (NumberOfCollidedAliveCells < OverPopulation))
                {
                    ChangedCellArray[id] = 0;
                }

            }
            else if (NumberOfCollidedAliveCells == NewLife)
            {
                ChangedCellArray[id] = 1;
            }
        }

        if (ChangedCellArray != MainCellArray)
        {
            System.Array.Copy(ChangedCellArray,MainCellArray,FieldSize*FieldSize*FieldSize);
        }

        else
        {
            DeleteAllCubes();
            GameObject View = GameObject.Find("MenuCanvas");
            View.GetComponent<Canvas>().enabled = true;
        }
    }

    void Start()
    {
        MainCellArray = new int[FieldSize * FieldSize * FieldSize];

        ChangedCellArray = new int[FieldSize * FieldSize * FieldSize];

        CellParametersArray = new Cell[FieldSize * FieldSize * FieldSize];

        AllLayersNumber = FieldSize / 2;

        CurrentLayers = AllLayersNumber;

        FieldSize = PlayerPrefs.GetInt("FieldSize", 10);

        for (int i = 0; i < FieldSize/2; i++)
        {
            LayersMDArray.Add(new List<Transform>());
        }

        for (int cellID = 0; cellID < (FieldSize*FieldSize*FieldSize); cellID++)
        {
            CellParametersArray[cellID] = new Cell();
            CellParametersArray[cellID].x = cellID % FieldSize;
            CellParametersArray[cellID].y = (cellID / FieldSize) % FieldSize;
            CellParametersArray[cellID].z = cellID / (FieldSize * FieldSize);
        }

        CreateLayerPrefab();
        CreateField();
    }

    private void Update()
    {

        if (BeginSimulation)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft < 0)
            {
                CheckOneStep();
                TimeLeft = AllTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckOneStep();
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (CurrentLayers < AllLayersNumber)
            {
                CurrentLayers += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (CurrentLayers > 1)
            {
                CurrentLayers -= 1;
            }
        }
    }
}
