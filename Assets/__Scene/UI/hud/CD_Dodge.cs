using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CD_Dodge : MonoBehaviour
{

	public Image CDReading;
	public bool imageOn = false;
	public float cdTime;
	//CD for dodge should be 5s
	public static float CDInitialTime = 5f;
	public Color cdColor;
	public Player playerAttached;


	// Use this for initialization
	void Start ()
	{
		CDReading = this.GetComponent<Image> ();
		cdColor = CDReading.color;
		cdColor.a = 0.85f;
		CDReading.color = cdColor;
		cdTime = 5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		cdTime = playerAttached.TimeNextFlash - Time.time;
		//print (cdTime);

		if (cdTime >= CDInitialTime) {
			print ("no image");
			CDReading.enabled = false;
			//cdColor.a = 0f;
		} else {
			print ("yes image");
			CDReading.enabled = true;
			cdColor.a = 0.85f;
			CDReading.fillAmount = cdTime / CDInitialTime;
		}
		
	}

	 

}
