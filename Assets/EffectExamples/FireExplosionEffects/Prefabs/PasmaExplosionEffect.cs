using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasmaExplosionEffect : MonoBehaviour {
    float countdown;
	// Use this for initialization
	void Start () {
        countdown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
