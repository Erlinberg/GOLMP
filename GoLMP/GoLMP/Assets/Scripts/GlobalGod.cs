using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGod : MonoBehaviour
{
    [SerializeField]
    public int FieldSize;

    public int ready = 0;

    public bool begin = false;

    public int[] SellArray = new int[1000];

    public int[] SellArrayCopy = new int[1000];

    public int LayersNum;

    public int Layers;

    private int sum = 0;

    public string[] CharacterNameList;

    [SerializeField]
    private float time = 1;

    private float timeLeft;

    private void CreateField()
    {
        for (int f = 0; f < FieldSize; f++)
        {
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    Instantiate(Resources.Load(CharacterNameList[PlayerPrefs.GetInt("CharacterIndex")]), new Vector3(j / 10.0f, (i / 10.0f) * -1, f / 10.0f), Quaternion.identity);
                }
            }
        }
    }

    private void RuleCnt()
    {
        for (int id = 0; id < Mathf.Pow(FieldSize,3); id++)
        {
            // Определение sum
            if (id - 1 > 0)
            {
                if (SellArray[id - 1] == 1)
                {
                    sum += 1;
                }
            }
            
            if (id + 1 < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + 1] == 1)
                {
                    sum += 1;
                }
            }

            if (id - FieldSize > 0)
            {
                if (SellArray[id - FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            if (id + FieldSize < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + FieldSize] == 1)
                {
                    sum += 1;
                }
            }

            if (id + Mathf.Pow(FieldSize, 2) < Mathf.Pow(FieldSize, 3))
            {
                if (SellArray[id + Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
                {
                    sum += 1;
                }
            }

            if (id - Mathf.Pow(FieldSize, 2) > 0)
            {
                if (SellArray[id - Mathf.RoundToInt(Mathf.Pow(FieldSize, 2))] == 1)
                {
                    sum += 1;
                }
            }
            // Окончание определения sum

            // Начало условий
            if (sum > 5)
            {
                SellArrayCopy[id] = 0;
            }

            if (sum <= 1)
            {
                SellArrayCopy[id] = 0;
            }

            if (sum == 3)
            {
                SellArrayCopy[id] = 1;
            }
            sum = 0;
        }
        SellArray = SellArrayCopy;
    }
    // Use this for initialization
    void Start()
    {
        CreateField();
        timeLeft = time;
    }

    private void Update()
    {
        //if (begin == true & Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    RuleCnt();
        //}
        if (begin == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                RuleCnt();
                timeLeft = time;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            begin = true;
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (Layers < LayersNum)
            {
                Layers += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (Layers > 1)
            {
                Layers -= 1;
            }
        }
    }
}
