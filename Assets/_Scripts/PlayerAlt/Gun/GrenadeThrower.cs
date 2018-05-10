using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour {
    public float throwForce = 140f;
    public GameObject grenadePrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void Throw (Player player) {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        Vector3 gg = player.FacingDirection;
        gg.Normalize();
        rb.AddForce(gg * throwForce, ForceMode.VelocityChange);
    }
}
