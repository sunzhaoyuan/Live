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
	public GameObject YunshiAlert;
	private Collider LeftSword;
	private Collider RightSword;
	//earthquake red circle

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

		Skills = new Dictionary<string, List<ASkill>> { {
				"close",
				new List<ASkill> {
					new Stab (),
					new Stab (),
					new Stab (),
					new Earthquake ()
				}
			}
			, {
				"far",
				new List<ASkill> {
					new Yunshi (),
					new EmptySkill (),
					new EmptySkill (),
					new EmptySkill (),
					new EmptySkill ()
				}
			}
		}; 
	}

	protected override void Awake ()
	{
		base.Awake ();
		IsAnimator = false;
		RightSword = GameObject.Find ("Weapon_Blade_Primary").GetComponent<BoxCollider> ();
		LeftSword = GameObject.Find ("Weapon_Blade_Secondary").GetComponent<BoxCollider> ();
//		YunshiAlert = GameObject.Find ("YunshiAlert");
	}


	public override void Attack ()
	{
		if (!CurrentSkill.Name.Equals ("Yunshi")) {
			gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		//CanDealDamage = true;
		if (CurrentSkill.Name.Equals ("Stab")) {
			if (IsStab1) {
				CurrentSkill.ActivateCollider (true, RightSword);
				CurrentSkill.ActivateCollider (false, LeftSword);
				Animation.Play ("Stab1");
				CanDealDamage = true;
			} else {
				CurrentSkill.ActivateCollider (true, LeftSword);
				CurrentSkill.ActivateCollider (false, RightSword);
				Animation.Play ("Stab2");
				CanDealDamage = true;
			}
			IsStab1 = !IsStab1;
		} else if (CurrentSkill.Name.Equals ("Earthquake") || CurrentSkill.Name.Equals ("Yunshi")) {
			Animation.Play ("Earthquake");
		}
	}

	public override void DecideState ()
	{
		base.DecideState ();
		if (!(CurrentState == State.ATTACK || CurrentState == State.IDLE)) {
			CurrentSkill.ActivateCollider (false, RightSword);
			CurrentSkill.ActivateCollider (false, LeftSword);
		}
		/// Only for activate collider of Earthquake
		if (CurrentSkill.Name.Equals ("Earthquake")) {
			EarthquakeAlert.SetActive (true);//activate the alert
			// Mathf.Abs (Time.time - AttackEndTime) <= 0.04f 保证collider在离AttackEndTime左右0.04秒的时间范围内被激活
			Collider c = gameObject.GetComponent<SphereCollider> ();
			if (0.01f <= AttackEndTime - Time.time && AttackEndTime - Time.time <= 0.5f) {
				CurrentSkill.ActivateCollider (true, c);
				CanDealDamage = true;
			} else {
				CurrentSkill.ActivateCollider (false, c);
				CanDealDamage = false;
			}
		} else {
			EarthquakeAlert.SetActive (false);
		}

		if (CurrentSkill.Name.Equals ("Yunshi")) {
			YunshiAlert.SetActive (true);//activate the alert
			// Mathf.Abs (Time.time - AttackEndTime) <= 0.04f 保证collider在离AttackEndTime左右0.04秒的时间范围内被激活
			Collider c = YunshiAlert.GetComponent<SphereCollider> ();
			if (0.01f <= AttackEndTime - Time.time && AttackEndTime - Time.time <= 0.5f) {
				CurrentSkill.ActivateCollider (true, c);
				CanDealDamage = true;
			} else {
				CurrentSkill.ActivateCollider (false, c);
				CanDealDamage = false;
			}
		} else {
			YunshiAlert.SetActive (false);
		}
	}

	public override void Die ()
	{
        EnemyMove(0f);
		if (!IsDead) {
			Animation.Play ("Die");
			IsDead = true;
			deadAnimDuration += Time.time; //update deadAniDuration to deadAnimEndTime
		}

		if (Time.time == deadAnimDuration) {
			transform.Rotate (new Vector3 (0f, 0f, 90f));
		}
	}
}
