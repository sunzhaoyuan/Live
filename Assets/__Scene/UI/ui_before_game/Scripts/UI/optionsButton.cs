using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsButton : MonoBehaviour {

	public void GotoMainMenu(){
		Application.LoadLevel ("MainMenuScene");
	}
}
