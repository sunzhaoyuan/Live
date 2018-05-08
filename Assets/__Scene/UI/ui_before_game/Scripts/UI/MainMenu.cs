using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public void PlayGame(){
		Application.LoadLevel ("Demo");
	}
	
	public void QuitGame(){
		Application.Quit();
	}
	
	public void GotoOptions(){
		Application.LoadLevel ("OptionScreen");
	}
	
	public void GotoOldScene(){
		Application.LoadLevel ("OldScene");
	}
	
	public void GotoCreditScene(){
		Application.LoadLevel ("Credit");
	}
}
