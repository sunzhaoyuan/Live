using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoRotation : MonoBehaviour {
	private float x0;
	private float birthTime;
	bool pressed;
	// Use this for initialization
	void Start () {
		x0 = pos.x; 
		birthTime = Time.time;
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,Time.deltaTime*50,0));
		if (pressed) {
			logoDown ();
		}
		if (Input.anyKeyDown) {
			pressed = true;

		}
	}

	void logoDown(){
		//transform.localPosition(new Vector3
		Vector3 tempPos = pos;
		tempPos.y -= 50 * Time.deltaTime;
		tempPos.z -= 50 * Time.deltaTime;
		pos = tempPos;
		if (tempPos.y < -180) {
			loader ();
		}

	}

	void loader(){
		Application.LoadLevel ("MainMenuScene");
	}

	public Vector3 pos { 
		get {
			return( this.transform.position );
		} 
		set {
			this.transform.position = value;
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSecondsRealtime (3);
	}
}
