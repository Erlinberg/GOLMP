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



    public int FieldSize;

    public int OverPopulation;

    public int UnderPopulation;

    public int NewLife;

    public int AllLayersNumber;

    public int CurrentLayers;

    private int NumberOfCollidedAliveCells = 0;



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

    private void CreateField()
    {
        for (int layerID = 0; layerID < FieldSize / 2; layerID++)
        {
            Instantiate(Resources.Load("Layers/" + "Layer " + layerID));
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

            WriteFunction("NumberOfCollidedAliveCells " + NumberOfCollidedAliveCells);

            if (MainCellArray[id] == 1)
            {
                if ((NumberOfCollidedAliveCells > UnderPopulation) || (NumberOfCollidedAliveCells < OverPopulation))
                {
                    ChangedCellArray[id] = 0;
                }

            }
            else
            {
                if (NumberOfCollidedAliveCells == NewLife)
                {
                    ChangedCellArray[id] = 1;
                }
            }
        }

        if (!(ChangedCellArray == MainCellArray))
        {
            System.Array.Copy(ChangedCellArray,MainCellArray,FieldSize*FieldSize*FieldSize);
        }

        else
        {
            DeleteAllCubes();
            GameObject View = GameObject.Find("MenuCanvas");
            View.GetComponent<Canvas>().enabled = true;
        }

        //// 12
        //if (id - 1 > 0)
        //{
        //    if (MainCellArray[id - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 14
        //if (id + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 10
        //if (id - FieldSize > 0)
        //{
        //    if (MainCellArray[id - FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 16
        //if (id + FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 22
        //if (id + Mathf.Pow(FieldSize, 2) < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 4
        //if (id - Mathf.Pow(FieldSize, 2) > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 8
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize + 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 6
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize - 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 7
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 5
        //if (id - Mathf.Pow(FieldSize, 2) + 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 3 
        //if (id - Mathf.Pow(FieldSize, 2) - 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 2
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize + 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 0
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize - 1 > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 1
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize > 0)
        //{
        //    if (MainCellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 9
        //if (id - FieldSize - 1 > 0)
        //{
        //    if (MainCellArray[id - FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 11
        //if (id - FieldSize + 1 > 0)
        //{
        //    if (MainCellArray[id - FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 15
        //if (id + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 17
        //if (id + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 21
        //if (id + Mathf.Pow(FieldSize, 2) - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 23
        //if (id + Mathf.Pow(FieldSize, 2) + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 19
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 18
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 20
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 24
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 25
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}

        //// 26
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (MainCellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
        //    {
        //        NumberOfCollidedAliveCells += 1;
        //    }
        //}
    }


    void Start()
    {
        MainCellArray = new int[FieldSize * FieldSize * FieldSize];

        ChangedCellArray = new int[FieldSize * FieldSize * FieldSize];

        CellParametersArray = new Cell[FieldSize * FieldSize * FieldSize];

        for (int cellID = 0; cellID < (FieldSize*FieldSize*FieldSize); cellID++)
        {
            CellParametersArray[cellID] = new Cell();
            CellParametersArray[cellID].x = cellID % FieldSize;
            CellParametersArray[cellID].y = (cellID / FieldSize) % FieldSize;
            CellParametersArray[cellID].z = cellID / (FieldSize * FieldSize);
        }

        CreateField();
    }

    private void Update()
    {
        if (BeginSimulation == true)
        {
            CheckOneStep();
            BeginSimulation = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BeginSimulation = true;
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
