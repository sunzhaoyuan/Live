using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackKickArea : MonoBehaviour
{

	private Xiaoxuemei Xxm;
	private float RotateDur;
	private float RotateEndTime;

	void Start ()
	{
		Xxm = gameObject.GetComponentInParent<Xiaoxuemei> ();
		RotateDur = 3f;
	}

	void OnTriggerEnter (Collider c)
	{	
		
		if (c.tag.Equals ("Player")) {
			Xxm.CurrentState = State.ATTACK;
			Xxm.CurrentSkill = new BackKick ();
			Debug.Log ("BackKick::OnTrigger");
			Xxm.transform.Rotate (new Vector3 (0, 180, 0));
			Xxm.ClearAnimState ();
			Xxm.ActivateAnimState ("IsAttack02");
			Xxm.LastAnimState = "IsAttack02";
			// TODO shoot kickblade;
		}
	}
	
}
