using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGod : MonoBehaviour
{
    [SerializeField]
    public int FieldSize;

    public int ready = 0;

    public bool begin = false;

    private int c = 0;

    public int[] SellArray = new int[100];

    public int[] SellArrayCopy = new int[100];

    private int sum = 0;

    private void CreateField()
    {
        for (int i = 0; i < FieldSize; i++)
        {
            for (int j = 0; j < FieldSize; j++)
            {
                Instantiate(Resources.Load("Cube"), new Vector3(j / 10.0f, (i / 10.0f) * -1, 0), Quaternion.identity);
                SellArray[c] = 0;
                SellArrayCopy[c] = 0;
                c++;
            }
        }
    }

    private void RuleCnt()
    {
        for (int id = 0; id < FieldSize * FieldSize; id++)
        {
            // Определение sum
            if (id - 1 > 0)
            {
                if (SellArray[id - 1] == 1)
                {
                    sum += 1;
                }
            }
            
            if (id + 1 < FieldSize * FieldSize)
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

            if (id + FieldSize < FieldSize * FieldSize)
            {
                if (SellArray[id + FieldSize] == 1)
                {
                    sum += 1;
                }
            }
            // Окончание определения sum

            // Начало условий
            if (sum > 3)
            {
                SellArrayCopy[id] = 0;
            }

            if (sum <= 1)
            {
                SellArrayCopy[id] = 0;
            }

            if (sum == 2)
            {
                SellArrayCopy[id] = 1;
            }
            Debug.Log(sum);
            sum = 0;
        }
        SellArray = SellArrayCopy;
    }
    // Use this for initialization
    void Start()
    {
        CreateField();
    }

    private void Update()
    {
        if (begin == true & Input.GetKeyDown(KeyCode.RightArrow))
        {
            RuleCnt();
        }

        if (Input.GetMouseButtonDown(1))
        {
            begin = true;
        }
    }
}
