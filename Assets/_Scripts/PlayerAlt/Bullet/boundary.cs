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

	void OnTriggerEnter (Collider collider)
	{
		string tag1 = collider.tag;
		Debug.Log (tag);

		switch (tag1) {
		case "Bullet":
		//	ABullet bullet = collider.gameObject.GetComponent<ABullet> ();
		//	CurrentHP -= bullet.Damage;
			Destroy (collider.gameObject);
			break;
		case "BondBullet":
		//	player.IsConnecting = true;
		//	player.ConnectingEnemy = this;
		//	if (Buff != null) {
		//		Buff.SetBuff (player);
		//		player.Buff = Buff;
		//	}
			Destroy (collider.gameObject);
			break;

		default :
			break;
		}



	}
}
