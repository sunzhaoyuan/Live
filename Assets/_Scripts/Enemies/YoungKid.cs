using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungKid : AEnemy
{

	// Need a field for Buff

	public YoungKid ()
	{
		Name = "YoungKid";
		MaxHP = 100f;
		Speed = 5f;
		CurrentState = State.IDLE;
	}

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		transform.LookAt (player.transform);
//		Vector3 relativePos = player.transform.position - Position;
//		relativePos.y = 0;
//		Quaternion rotation = Quaternion.LookRotation (relativePos);
//		transform.rotation = rotation;
		EnemyLookAt (90f);
		EnemyMove (2f);
	}
}
