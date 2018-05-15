using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {
    // AudioSource Audio;

    public float Damage;
    public float CountDown;
  
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2f);
        CountDown = Time.time + 0.5f; ;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= CountDown)
		    gameObject.GetComponent<BoxCollider>().enabled = false ;
	}
}
