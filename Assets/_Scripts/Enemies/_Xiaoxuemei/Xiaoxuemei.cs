
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoxuemei : AEnemy
{

	public Xiaoxuemei ()
	{
		Name = "Xiaoxuemei";
		MaxHP = 1000f;
		CurrentHP = 1000f;
		CurrentState = State.IDLE;
		Buff = new EmptyBuff ();
//		IsAnimator = true;
	}

	protected override void Awake ()
	{
		base.Awake ();
		IsAnimator = true;
	}

	public override void DecideState ()
	{
		if (CurrentHP <= 0) {
			CurrentState = State.DIED;
			return;
		}
		if (Time.time >= NextAttackTime) {
			float distance = Mathf.Abs (Vector3.Distance (Position, player.transform.position));

			System.Random ran = new System.Random ();
			int AttackPercent = ran.Next (100);
			int PunchPer = 0, StrikePer = 0, MovePer = 0;
			if (distance <= closeRange) {
				StrikePer = 0;
				PunchPer = 90;
			} else if (distance <= midRange) {
				MovePer = 50;
				StrikePer = 23;
				PunchPer = 22;
			} else if (distance <= farRange) {
				MovePer = 50;
				StrikePer = 35;
				PunchPer = 15;
			} else
				MovePer = 100;

			if (AttackPercent <= MovePer) {
				CurrentState = State.MOVE;
				NextAttackTime = Time.time + 2f;
				return;
			} else if (AttackPercent <= MovePer + StrikePer) {
				// do no need animation
				ClearAnimState ();
				CurrentSkill = new Strike ();
			} else if (AttackPercent <= MovePer + StrikePer + PunchPer) {
				ClearAnimState ();
				CurrentSkill = new Punch ();
				Animator.SetBool ("IsAttack01", true);
				LastAnimState = "IsAttack01";
			} else {
				Debug.Log ("Xiaoxuemei:: " + "BladeFlash");
				ClearAnimState ();
				CurrentSkill = new Bladeflash (5f, 4f, 1f);

			}
			CurrentState = State.ATTACK;
			AttackEndTime = Time.time + CurrentSkill.Duration;
			NextAttackTime = AttackEndTime + CurrentSkill.Cooldown;
		} else if (Time.time <= AttackEndTime)
			CurrentState = State.ATTACK;
		else {
			ClearAnimState ();
			LastAnimState = ""; //clear
			CurrentState = State.MOVE;
		}
	}

	public override void Attack ()
	{
		CurrentSkill.UseSkill (this, player);
	}

	public override void Die ()
	{
		Animator.SetBool ("IsDead", true);
	}
}
