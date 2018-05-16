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
	public bool change = false;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			this.changeWeapon();
			this.change = false;

		}
	}

	void changeWeapon(){

		if (state == 1) {
			image.sprite = Weapon2Material;
			this.state = 2;
		} else {
			image.sprite = Weapon1Material;
			this.state = 1;
		}

	}
}
