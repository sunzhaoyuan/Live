using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasmaExplosionEffect : MonoBehaviour {
    float countdown;
    AudioSource Audio;
    public AudioClip flash;


    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    void Start () {
        countdown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
       // Audio.clip = flash;
        //Audio.Play();
        if (countdown <= 0f)
        {
            
            Destroy(gameObject);
        }
	}
}
