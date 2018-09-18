using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterListController : MonoBehaviour {

    private GameObject[] CharacterList;


    private int Index = 0;




    public void ToggleLeft()
    {
        CharacterList[Index].SetActive(false);

        Index--;

        if (Index < 0)
        {
            Index = CharacterList.Length - 1;
        }

        CharacterList[Index].SetActive(true);
    }

    public void ToggleRight()
    {
        CharacterList[Index].SetActive(false);

        Index++;

        if (Index == CharacterList.Length)
        {
            Index = 0;
        }

        CharacterList[Index].SetActive(true);
    }

    public void Select()
    {
        PlayerPrefs.SetInt("CharacterIndex", Index);
        SceneManager.LoadScene("AAAB");
    }

    void Start()
    {
        CharacterList = new GameObject[transform.childCount];

        for (int id = 0; id < transform.childCount; id++)
        {
            CharacterList[id] = transform.GetChild(id).gameObject;
        }

        foreach (GameObject characterObject in CharacterList)
        {
            characterObject.SetActive(false);
        }

        if (CharacterList[0])
        {
            CharacterList[0].SetActive(true);
        }


    }
}
