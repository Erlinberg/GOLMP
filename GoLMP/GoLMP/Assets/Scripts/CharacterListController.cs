using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterListController : MonoBehaviour {

    private GameObject[] CharacterList;

    private int index = 0;

	void Start ()
    {
        CharacterList = new GameObject[transform.childCount];
         for (int i = 0;i < transform.childCount;i++)
        {
            CharacterList[i] = transform.GetChild(i).gameObject;
        }

         foreach (GameObject go in CharacterList)
        {
            go.SetActive(false);
        }

        if (CharacterList[0])
        {
            CharacterList[0].SetActive(true);
        }
        
	}

    public void ToggleLeft()
    {
        CharacterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = CharacterList.Length - 1;
        }

        CharacterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        CharacterList[index].SetActive(false);

        index++;
        if (index == CharacterList.Length)
        {
            index = 0;
        }

        CharacterList[index].SetActive(true);
    }

    public void Select()
    {
        PlayerPrefs.SetInt("CharacterIndex", index);
        SceneManager.LoadScene("AAAB");
    }
}
