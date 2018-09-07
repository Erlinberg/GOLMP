using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGod : MonoBehaviour
{
    [SerializeField]
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

    [SerializeField]
    private float time = 1;

    private float timeLeft;

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
        for (int id = 0; id < Mathf.Pow(FieldSize,3); id++)
        {
            // Определение sum

            // 12
            if (id - 1 > 0)
            {
                if (SellArray[id - 1] == 1)
                {
                    sum += 1;
                }
            }
            
            // 14
            if (id + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 10
            if (id - FieldSize > 0)
            {
                if (SellArray[id - FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 16
            if (id + FieldSize < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 22
            if (id + Mathf.Pow(FieldSize, 2) < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
                {
                    sum += 1;
                }
            }

            // 4
            if (id - Mathf.Pow(FieldSize, 2) > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
                {
                    sum += 1;
                }
            }

            // 8
            if (id - Mathf.Pow(FieldSize, 2) + FieldSize + 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 6
            if (id - Mathf.Pow(FieldSize, 2) + FieldSize - 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 7
            if (id - Mathf.Pow(FieldSize, 2) + FieldSize > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 5
            if (id - Mathf.Pow(FieldSize, 2) + 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 3 
            if (id - Mathf.Pow(FieldSize, 2) - 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 2
            if (id - Mathf.Pow(FieldSize, 2) - FieldSize + 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 0
            if (id - Mathf.Pow(FieldSize, 2) - FieldSize - 1 > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 1
            if (id - Mathf.Pow(FieldSize, 2) - FieldSize > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 9
            if (id - FieldSize - 1 > 0)
            {
                if (SellArray[id - FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 11
            if (id - FieldSize + 1 > 0)
            {
                if (SellArray[id - FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 15
            if (id + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 17
            if (id + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 21
            if (id + Mathf.Pow(FieldSize, 2) - 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 23
            if (id + Mathf.Pow(FieldSize, 2) + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 19
            if (id + Mathf.Pow(FieldSize, 2) - FieldSize < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 18
            if (id + Mathf.Pow(FieldSize, 2) - FieldSize - 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 20
            if (id + Mathf.Pow(FieldSize, 2) - FieldSize + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) - FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // 24
            if (id + Mathf.Pow(FieldSize, 2) + FieldSize - 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize - 1] == 1)
                {
                    sum += 1;
                }
            }

            // 25
            if (id + Mathf.Pow(FieldSize, 2) + FieldSize < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            // 26
            if (id + Mathf.Pow(FieldSize, 2) + FieldSize + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2)) + FieldSize + 1] == 1)
                {
                    sum += 1;
                }
            }

            // Окончание определения sum
            // Начало условий

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
            sum = 0;
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
    }

    void Start()
    {
        SellArray = new int[FieldSize * FieldSize * FieldSize];
        SellArrayCopy = new int[FieldSize * FieldSize * FieldSize];
        CreateField();
        timeLeft = time;
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
