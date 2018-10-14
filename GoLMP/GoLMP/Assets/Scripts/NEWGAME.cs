using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWGAME : MonoBehaviour {

	private int FieldSize;

	public void Select()
    {
        SceneManager.LoadScene("SelectCharacter");
    }

	public void ChangeFieldSize(string Text)
	{
		if(int.Parse(Text) <= 0)
		{
			FieldSize = 5;
		}
		else if(int.Parse(Text) > 10)
		{
			FieldSize = 10;
		}

		FieldSize = int.Parse(Text);

		PlayerPrefs.SetInt("FieldSize", FieldSize);
	}
}
