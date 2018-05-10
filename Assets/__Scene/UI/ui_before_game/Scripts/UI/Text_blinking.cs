using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_blinking : MonoBehaviour {
	public float timer;
	public bool pressed;
	// Use this for initialization
	void Start () {
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown) {
			print ("button pressed");
			pressed = true;
		}
		if (!pressed) {
			timer += Time.deltaTime;
			if (timer >= 0.5) {
				GetComponent<Text> ().enabled = true;
			}
			if (timer >= 1) {
				GetComponent<Text> ().enabled = false;
				timer = 0;
			}
		} else {
			GetComponent<Text> ().enabled = false;
		}
	}
}
