using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("AAAB");
    }
	
    public void ChangeCharacter()
    {
        SceneManager.LoadScene("SelectCharacter");
    }
}
