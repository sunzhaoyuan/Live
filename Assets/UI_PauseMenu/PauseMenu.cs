using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public static bool Paused = false;
	//[Header("Set in Inspector")]
	public GameObject pauseMenuUI;
	public GameObject creditUI;
    public GameObject controlUI;
    public GameObject nextLevelMenuUI;
	public GameObject resumeButton;
	public GameObject backButton;
    public GameObject backFromControlButton;
    public GameObject restartButton;
	public GameObject nextButton;
	public EventSystem m_EventSystem;
	public GameObject youLoseText;

	public AEnemy ap;
	//change to Enemy(GameObject)
	public Player p;
//

	void Start ()
	{

		m_EventSystem = EventSystem.current;
		Resume ();
		creditUI.SetActive (false);
        controlUI.SetActive(false);
        nextLevelMenuUI.SetActive (false);
	}

	void Update ()
	{
		if (Time.timeScale != 0f) {
			if (ap.CurrentHP == -1f) {//change to Enemy.isDead ?
				Next ();
			}
			if (p.CurrentHP == 0f) {//change to Enemy.isDead ?
				YouDie ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown("joystick button 9")) {
			if (Paused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	public void Resume ()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		Paused = false;
	}

	public void Pause ()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		Paused = true;
		m_EventSystem.SetSelectedGameObject (resumeButton);
	}

	public void PlayGame ()
	{
		Application.LoadLevel ("_Scene_1");
	}

	public void PlayLevel2 ()
	{
		Application.LoadLevel ("_Scene_2");
	}

	public void QuitGame ()
	{
        Application.LoadLevel("MainMenuScene");
    }

	public void GotoOptions ()
	{
        Debug.Log("Not in use");
        //Application.LoadLevel ("OptionScreen");
	}

	public void GotoOldScene ()
	{
		Debug.Log ("Not in use");
		//Application.LoadLevel ("OldScene");
	}

	public void GotoCredit ()
	{
		pauseMenuUI.SetActive (false);
		creditUI.SetActive (true);
		nextLevelMenuUI.SetActive (false);
		m_EventSystem.SetSelectedGameObject (backButton);
	}

    public void GotoControl()
    {
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(true);
        nextLevelMenuUI.SetActive(false);
        m_EventSystem.SetSelectedGameObject(backFromControlButton);
    }

    public void Back ()
	{
		pauseMenuUI.SetActive (true);
		creditUI.SetActive (false);
		nextLevelMenuUI.SetActive (false);
		m_EventSystem.SetSelectedGameObject (resumeButton);
	}

    public void BackFromControl()
    {
        pauseMenuUI.SetActive(true);
        controlUI.SetActive(false);
        nextLevelMenuUI.SetActive(false);
        m_EventSystem.SetSelectedGameObject(resumeButton);
    }

    public void YouDie ()
	{
		nextLevelMenuUI.SetActive (true);
		Time.timeScale = 0f;
		Paused = true;
		nextButton.SetActive (false);
		youLoseText.SetActive (true);
		m_EventSystem.SetSelectedGameObject (restartButton);
	}

	public void Next ()
	{
		nextLevelMenuUI.SetActive (true);
		Time.timeScale = 0f;
		Paused = true;
		nextButton.SetActive (true);
		youLoseText.SetActive (false);
		m_EventSystem.SetSelectedGameObject (nextButton);
	}
}
