using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
	public float speed = 80f;
	public float damage = 20f;
	// Use this for initialization
	// Vector3 inputDirectionR;
	// GameObject weapon;
    
	
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log (speed);
		transform.Translate (Vector3.forward * this.speed * Time.deltaTime);
	}
}
