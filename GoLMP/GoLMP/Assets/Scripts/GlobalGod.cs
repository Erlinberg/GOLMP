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

    public Cell[] CellParameters;

    public int FieldSize;

    public int Max_for_live;

    public int Min_for_live;

    public int Optimal_for_birth;

    public bool begin = false;

    public int[] SellArray;

    public int[] SellArrayCopy;

    public int LayersNum;

    public int Layers;

    private int sum = 0;

    public string[] CharacterNameList;

    private int x, y, z, id, new_x, new_y, new_z;

    private int[] delta = new int[3];




    private void Write(string text)
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

    private int Get_id()
    {
        return new_z * (FieldSize * FieldSize) + new_y * FieldSize + new_x;
    }

    private int In_field(int dx, int dy, int dz)
    {
        new_x = CellParameters[id].x + dx;
        new_y = CellParameters[id].y + dy;
        new_z = CellParameters[id].z + dz;
        if (dx == 0 & dy == 0 & dz == 0)
            return 0;
        else if (new_x < 0 || new_x > FieldSize - 1)
            return 0;

        else if (new_y < 0 || new_y > FieldSize - 1)
            return 0;

        else if (new_z < 0 || new_z > FieldSize - 1)
            return 0;
        else
        {
            return SellArray[Get_id()];
        }
    }

    private void Sum_around()
    {
        sum = 0;
        delta[0] = -1;
        delta[1] = 0;
        delta[2] = 1;
        foreach (int dx in delta)
            foreach (int dy in delta)
                foreach (int dz in delta)
                {
                    sum += In_field(dx, dy, dz);
                }
    }

    private void CreateField()
    {
        for (int f = 0; f < FieldSize / 2; f++)
        {
            Instantiate(Resources.Load("Layers/" + "Layer " + f));
        }
    }

    private void DeleteAllCubes()
    {
        for(int i = 0;i < FieldSize * FieldSize * FieldSize; i++)
        {
            SellArray[i] = -1;
        }
    }

    private void RuleCnt()
    {
        for (int _id = 0; _id < Mathf.Pow(FieldSize, 3); _id++)
        {
            id = _id;
            Sum_around();

            Write("sum " + sum);

            if (SellArray[id] == 1)
            {
                if (sum > Max_for_live || sum < Min_for_live)
                {
                    SellArrayCopy[id] = 0;
                }

            }
            else
            {
                if (sum == Optimal_for_birth)
                {
                    SellArrayCopy[id] = 1;
                }
            }
        }

        if (!(SellArrayCopy == SellArray))
        {
            System.Array.Copy(SellArrayCopy,SellArray,FieldSize*FieldSize*FieldSize);
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
        //    if (SellArray[id - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 14
        //if (id + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 10
        //if (id - FieldSize > 0)
        //{
        //    if (SellArray[id - FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 16
        //if (id + FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 22
        //if (id + Mathf.Pow(FieldSize, 2) < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 4
        //if (id - Mathf.Pow(FieldSize, 2) > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 8
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize + 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 6
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize - 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 7
        //if (id - Mathf.Pow(FieldSize, 2) + FieldSize > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 5
        //if (id - Mathf.Pow(FieldSize, 2) + 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 3 
        //if (id - Mathf.Pow(FieldSize, 2) - 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 2
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize + 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 0
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize - 1 > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 1
        //if (id - Mathf.Pow(FieldSize, 2) - FieldSize > 0)
        //{
        //    if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 9
        //if (id - FieldSize - 1 > 0)
        //{
        //    if (SellArray[id - FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 11
        //if (id - FieldSize + 1 > 0)
        //{
        //    if (SellArray[id - FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 15
        //if (id + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 17
        //if (id + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 21
        //if (id + Mathf.Pow(FieldSize, 2) - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 23
        //if (id + Mathf.Pow(FieldSize, 2) + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 19
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 18
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 20
        //if (id + Mathf.Pow(FieldSize, 2) - FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 24
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 25
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
        //    {
        //        sum += 1;
        //    }
        //}

        //// 26
        //if (id + Mathf.Pow(FieldSize, 2) + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
        //{
        //    if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
        //    {
        //        sum += 1;
        //    }
        //}
    }

    void Start()
    {
        SellArray = new int[FieldSize * FieldSize * FieldSize];
        SellArrayCopy = new int[FieldSize * FieldSize * FieldSize];
        CellParameters = new Cell[FieldSize * FieldSize * FieldSize];
        for (int i = 0; i < (FieldSize*FieldSize*FieldSize); i++)
        {
            CellParameters[i] = new Cell();
            CellParameters[i].x = i % FieldSize;
            CellParameters[i].y = (i / FieldSize) % FieldSize;
            CellParameters[i].z = i / (FieldSize * FieldSize);
        }
        CreateField();
    }

    private void Update()
    {
        if (begin == true)
            RuleCnt();
            begin = false;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            begin = true;

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (Layers < LayersNum)
            {
                Layers++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (Layers > 1)
            {
                Layers--;
            }
        }
    }
}
