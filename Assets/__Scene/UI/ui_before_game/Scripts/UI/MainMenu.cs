using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    public void PlayGame(){
		Application.LoadLevel ("_Scene_1");
	}

    public void PlayGame2()
    {
        Application.LoadLevel("_Scene_2");
    }

    public void QuitGame(){
		Application.Quit();
	}

    public void GotoControl()
    {
        Application.LoadLevel("ControlScene");
    }
    

    public void GotoCreditScene(){
		Application.LoadLevel ("Credit");
	}
}
