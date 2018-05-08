using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aniki - The first boss.
/// </summary>
public class Aniki : AEnemy
{
	private bool IsStab1;
	public GameObject EarthquakeAlert;

	//	public string Name = "Aniki";
	//	public float CurrentHP = 1000f;

	public Aniki ()
	{
		Name = "Aniki";
		MaxHP = 1000f;
		CurrentHP = 1000f;
		Speed = 5f;
		CurrentState = State.IDLE;
		closeRange = 8f;
		deadAnimDuration = 1f;
		IsStab1 = true;
		Buff = new EmptyBuff ();
//		CurrentSkill = new Stab ();
//		Buff = null;
		Skills = new Dictionary<string, List<ASkill>> { {"close", new List<ASkill> {new StabAlt (), new StabAlt (), new StabAlt (), new Earthquake ()
				}
			}
		};
	}


	protected override void Attack ()
	{
		
		if (CurrentSkill.Name.Equals ("Stab")) {
			if (IsStab1)
				anim.Play ("Stab1");
			else
				anim.Play ("Stab2");
			IsStab1 = !IsStab1;
		} else {
			anim.Play ("Earthquake");

		}
	}

	protected override void DecideState ()
	{
		base.DecideState ();
		// Only for activate collider of Earthquake
		if (CurrentSkill.Name.Equals ("Earthquake")) {
			EarthquakeAlert.SetActive (true);//activate the alert
			// Mathf.Abs (Time.time - AttackEndTime) <= 0.04f 保证collider在离AttackEndTime左右0.04秒的时间范围内被激活
			Collider c = gameObject.GetComponent<SphereCollider> ();
			if (Mathf.Abs (Time.time - AttackEndTime) <= 0.04f) {
				Debug.Log ("Aniki::Activate");
				CurrentSkill.ActivateCollider (true, c);
	
			} else {
				Debug.Log ("Aniki::DEactivate");
				CurrentSkill.ActivateCollider (false, c);
			}
		} else {
			EarthquakeAlert.SetActive (false);
		}
	}

	protected override void Die ()
	{
		base.Die ();
		if (Time.time == deadAnimDuration) {
			transform.Rotate (new Vector3 (0f, 0f, 90f));
		}
	}
}
