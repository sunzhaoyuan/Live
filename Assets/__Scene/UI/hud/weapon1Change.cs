using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon1Change : MonoBehaviour {


	[Header ("Set in Inspector")]
	public Image image;
	public Sprite Weapon1Material;
	public Sprite Weapon2Material;
	public int state = 1;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("change weapon");
			this.changeWeapon();

		}
	}

	void changeWeapon(){

		if (state == 1) {
			image.sprite = Weapon2Material;
			this.state = 2;
			print ("weapon 1 change from 1 to 2");
		} else {
			image.sprite = Weapon1Material;
			this.state = 1;
			print ("weapon 1 change from 2 to 1");
		}

	}
}
