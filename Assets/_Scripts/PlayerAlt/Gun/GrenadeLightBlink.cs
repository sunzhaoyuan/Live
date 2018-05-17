using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLightBlink : MonoBehaviour
{

	public float BlinkPeriod;
	private Light light;

	// Use this for initialization
	void Start ()
	{
		light = gameObject.GetComponent<Light> ();
		StartCoroutine (WaitForNextBlink ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		

	}

	IEnumerator WaitForNextBlink ()
	{
		while (true) {
			Debug.Log ("Boo");
			light.enabled = !light.enabled;
			yield return new WaitForSeconds (BlinkPeriod);
		}

	}
}
