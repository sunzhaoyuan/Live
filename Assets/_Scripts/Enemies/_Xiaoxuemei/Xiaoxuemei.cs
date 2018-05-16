using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xiaoxuemei : AEnemy
{
    //	// same as Player::gunfire
    //	public GameObject GunFire;
    public Collider RightArm;
    public Collider LeftArm;
    public GameObject RightArmgo;
    public GameObject LeftArmgo;
    public SphereCollider YishanColl;
    public Image bossHP;

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
        RightArm = RightArmgo.GetComponent<BoxCollider>();
        LeftArm = LeftArmgo.GetComponent<BoxCollider>();
        YishanColl = gameObject.GetComponent<SphereCollider>();
    }

	public override void DecideState ()
	{
        //Debug.Log(Mathf.Abs(Vector3.Distance(Position, player.transform.position)));
		if (CurrentHP <= 0) {
			CurrentState = State.DIED;
			return;
		}
        if (Time.time >= WeakEndTime)
            IsWeak = false;
        if (IsWeak)
        {
            CurrentState = State.IDLE;
            DeactivateAnimState("IsRun");
            DeactivateAnimState("IsAttack01");
            return;
        }
		if (Time.time >= NextAttackTime) {
            CurrentSkill.ActivateCollider(false, RightArm);
            CurrentSkill.ActivateCollider(false, LeftArm);
            float distance = Mathf.Abs (Vector3.Distance (Position, player.transform.position));
			System.Random ran = new System.Random ();
			int AttackPercent = ran.Next (100);
			int PunchPer = 0, StrikePer = 0, MovePer = 0;
			if (distance <= closeRange) {
				PunchPer = 90;
			} else if (distance <= midRange) {
				MovePer = 50;
				StrikePer = 25;
				PunchPer = 24;
			} else if (distance <= farRange) {
				MovePer = 50;
				StrikePer = 37;
				PunchPer = 17;
			} else
				MovePer = 100;
            CanDealDamage = true;
			if (AttackPercent <= MovePer) {
                CanDealDamage = false;
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
                CurrentSkill.ActivateCollider(true, RightArm);
                CurrentSkill.ActivateCollider(true, LeftArm);
                Animator.SetBool ("IsAttack01", true);
				LastAnimState = "IsAttack01";
			} else {
				//Debug.Log ("Xiaoxuemei:: " + "BladeFlash");
				ClearAnimState ();
				CurrentSkill = new Bladeflash (1f, 2f, .2f, this);

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

    protected override void Update()
    {
        base.Update();
        bossHP.fillAmount = CurrentHP / MaxHP;
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
