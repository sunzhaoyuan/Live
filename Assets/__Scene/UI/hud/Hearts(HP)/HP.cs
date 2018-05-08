using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
	[Header( "Set in Inspector" )]
	//public Text uitHp; // The UIText_Level Text
	public Image uitHPbar;
	public Text uitBuff;
	[Header( "Set Dynamically" )]

	public float hp=100f;
	public string bf="";
	// Use this for initialization

	void Start () {
		hp=30f;
	}

	// Update is called once per frame
	void Update () {
		uitHPbar.fillAmount = hp/100f;
		uitBuff.text="Buff: "+bf;
	}
}
