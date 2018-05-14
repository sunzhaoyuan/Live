using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision)
	{
		GameObject go= collision.gameObject;
		string tag1 = go.tag;
	
		switch (tag1) {
		case "Bullet":
			Destroy (collision.gameObject);
			break;
		case "BondBullet":
			Destroy (collision.gameObject);
			break;

		default :
			break;
		}



	}
}
