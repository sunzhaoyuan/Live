using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
	public bool isFiring;
	public BulletControl bullet;
	public float timeBetweenshots;
	public float shotCounter;
	public Transform firepoint;
	public float timeNextShot = 0.5f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (isFiring) {
			//print (Time.time - timeLastShot);
			if (Time.time >= timeNextShot) {
				
				timeNextShot = Time.time + timeBetweenshots;
				BulletControl newBullet = Instantiate (bullet, transform.position, this.transform.rotation) as BulletControl;
            
			}
		}
	}
}
