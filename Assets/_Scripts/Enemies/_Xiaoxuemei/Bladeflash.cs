using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bladeflash : ASkill
{
	enum XueMeiState
	{
		DEFAULT,
		FACING,
		CHARGING,
		FLASHING
	}

	private XueMeiState CurrentState;

	private float FacingEndTime;
	private float ChargingEndTime;
	private float FlashEndTime;
	private float FacingDur;
	private float ChargeDur;
	private float FlashDur;


	public Bladeflash (float facingDur, float chargeDur, float flashDur)
	{
		Name = "Bladeflash";
		Duration = 10f;

		CurrentState = XueMeiState.FACING;
		FacingDur = facingDur;
		ChargeDur = chargeDur;
		FlashDur = flashDur;

		FacingEndTime = Time.time + FacingDur;
		ChargingEndTime = FacingEndTime + ChargeDur;
		FlashEndTime = ChargingEndTime + FlashDur;
//		Debug.Log ("BladeFlash::FacingEndTime " + FacingEndTime);
	}

	public override void UseSkill (AEnemy enemy, Player player)
	{
		if (Time.time <= FacingEndTime) { // switch to charging
			CurrentState = XueMeiState.FACING;
		} else if (Time.time <= ChargingEndTime) { // switch to flash
			CurrentState = XueMeiState.CHARGING;
			Debug.Log ("CharingEndTime:" + FlashEndTime);
		} else if (Time.time <= FlashEndTime) { // skill end, switch to empty
			CurrentState = XueMeiState.FLASHING;
		} else {
			CurrentState = XueMeiState.DEFAULT;
		}

		switch (CurrentState) {
		case XueMeiState.FACING:
			enemy.DeactivateAnimState ("IsRun");
			enemy.EnemyMove (0f);
			enemy.EnemyLookAt ();
			break;
		case XueMeiState.CHARGING:
			enemy.DeactivateAnimState ("IsRun");
			enemy.EnemyMove (0f);
			break;
		case XueMeiState.FLASHING:
			enemy.ActivateAnimState ("IsRun");
			enemy.EnemyMove (30f);
			break;
		default:
			break;
		}
		Debug.Log ("BladeFlash::CurrentState " + CurrentState);
	}

}
