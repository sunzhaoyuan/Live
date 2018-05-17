using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class controlScene : MonoBehaviour {

    public void Back()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
