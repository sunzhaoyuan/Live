using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	[Header ("Set in Inspector")]
	public Text uitHp;


	public GameObject player;
	[Header ("Set Dynamically")]

	public float hp = 100f;
	// Use this for initialization
	void Start ()
	{
		
	}

	void Update ()
	{
		// Show the data in the GUITexts
		float hp = player.GetComponent<playerControl> ().CurrentHP;
		Debug.Log ("HP: " + hp);
		uitHp.text = "HP: " + hp;
	}

}

