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

	public float FacingEndTime;
	public float ChargingEndTime;
	public float FlashEndTime;
	private float FacingDur;
	private float ChargeDur;
	private float FlashDur;
    private bool HasFlashed;
    private Xiaoxuemei Xuemei;


	public Bladeflash (float facingDur, float chargeDur, float flashDur, Xiaoxuemei income)
	{
		Name = "Bladeflash";
        Duration = facingDur + chargeDur + flashDur + .2f ;
        Damage = 10000f;
        Xuemei = income;
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
            //Debug.Log(ChargingEndTime - Time.time);
		} else if (Time.time <= FlashEndTime) { // skill end, switch to empty
			CurrentState = XueMeiState.FLASHING;
		} else {
			CurrentState = XueMeiState.DEFAULT;
		}

		switch (CurrentState) {
		case XueMeiState.FACING:
			Xuemei.DeactivateAnimState ("IsRun");
			Xuemei.EnemyMove (0f);
			Xuemei.EnemyLookAt ();
			break;
		case XueMeiState.CHARGING:
			Xuemei.DeactivateAnimState ("IsRun");
			Xuemei.EnemyMove (0f);
			break;
		case XueMeiState.FLASHING:
            if (0.15f <= FlashEndTime - Time.time && FlashEndTime - Time.time <= 0.2)
                Xuemei.YishanColl.radius = 2f;
            else
                Xuemei.YishanColl.radius = .29f;
            if (!HasFlashed)
            {
                Xuemei.transform.position = player.transform.position - 10f * player.transform.forward;
                Xuemei.ActivateAnimState ("IsAttack01");
                Xuemei.EnemyLookAt();
                HasFlashed = true;
            }
            Xuemei.EnemyMove (0f);
			break;
		default:
            if (player.Buff.Name.Equals("StoneSkin"))
            {
                Xuemei.DeactivateAnimState("IsAttack01");
                Xuemei.IsWeak = true;
                Xuemei.WeakEndTime = Time.time + 5f;
            }
			break;
		}
		//Debug.Log ("BladeFlash::CurrentState " + CurrentState);
	}

}
