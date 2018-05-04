using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		float distance;
		Vector3 forward = transform.TransformDirection (Vector3.forward)*10;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, (forward), out hit)) {
			print ("hit " + hit.collider.gameObject.name);
		}
	}
}
