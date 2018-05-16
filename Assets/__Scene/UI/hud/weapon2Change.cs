using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon2Change : MonoBehaviour {

	[Header ("Set in Inspector")]
	public Image image;
	public int state = 2;
	public Sprite Weapon1Material;
	public Sprite Weapon2Material;
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
		if (state == 2) {
			this.state = 1;
			image.sprite = Weapon1Material;
		} else {
			this.state = 2;
			image.sprite = Weapon2Material;
		}

	}
}
