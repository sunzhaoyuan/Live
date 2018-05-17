using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCD : MonoBehaviour {
	public Image CDReading;
	public bool imageOn = false;
    public Color cdColor;
    public Player playerAttached;

    // Use this for initialization
    void Start () {
		CDReading = this.GetComponent<Image> ();
		Color cdColor = CDReading.color;
		cdColor.a = 0.85f;
		CDReading.color = cdColor;
	}
	
	// Update is called once per frame
	void Update () {
        float cdTime = playerAttached.NextGranadeTime - Time.time;
        float CDInitialTime = 5f;
        //print (cdTime);

        if (cdTime >= CDInitialTime)
        {
            CDReading.enabled = false;
            //cdColor.a = 0f;
        }
        else
        {
            CDReading.enabled = true;
            cdColor.a = 0.85f;
            CDReading.fillAmount = cdTime / CDInitialTime;
        }
    }
}
