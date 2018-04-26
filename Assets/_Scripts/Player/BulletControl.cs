using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    public float speed;
	public float damage;
    // Use this for initialization
   // Vector3 inputDirectionR;
   // GameObject weapon;
    

    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
	}
}
