using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CD_Skill : MonoBehaviour
{

	public Image CDReading;
	public bool imageOn = false;
	public Player playerAttached;

	// Use this for initialization
	void Start ()
	{
		CDReading = this.GetComponent<Image> ();
		Color cdColor = CDReading.color;
		cdColor.a = 0.85f;
		CDReading.color = cdColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((playerAttached.Bond.TimeNextShot - Time.time) <= 0) {
			CDReading.enabled = false;
		} else {
			CDReading.enabled = true;
		}
		
	}

	 

}
