using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close_Menu : MonoBehaviour {

    public GameObject Menu;

    

    public void MenuControll()
    {
        Menu.SetActive((Menu.activeSelf == false));
    }
}
