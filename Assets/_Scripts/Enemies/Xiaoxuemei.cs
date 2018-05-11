
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoxuemei : AEnemy {

    public Xiaoxuemei(){
        Name = "Xiaoxuemei";
		MaxHP = 1000f;
		CurrentHP = 1000f;
		CurrentState = State.IDLE;
		Buff = new EmptyBuff();
    }

    public override void DecideState()
    {
        if (CurrentHP <= 0)
        {
            CurrentState = State.DIED;
            return;
        }
        if (Time.time >= NextAttackTime)
        {
            float distance = Mathf.Abs(Vector3.Distance(Position, player.transform.position));
            System.Random ran = new System.Random();
            int AttackPercent = ran.Next(100);
            int PunchPer = 0, StrikePer = 0, MovePer = 0;

            if (0 <= distance && distance <= closeRange)
            {
                StrikePer = 30;
                PunchPer = 60;
            }
            else if (distance <= midRange)
            {
                MovePer = 50;
                StrikePer = 23;
                PunchPer = 22;
            }
            else
            {
                MovePer = 50;
                StrikePer = 35;
                PunchPer = 15;
            }

            if (AttackPercent <= MovePer)
            {
                CurrentState = State.MOVE;
                NextAttackTime = Time.time + 2f;
                return;
            }
            else if (AttackPercent <= MovePer + StrikePer)
                CurrentSkill = new Strike();
            else if (AttackPercent <= MovePer + StrikePer + PunchPer)
                CurrentSkill = new Punch();
            else
                CurrentSkill = new Bladeflash();
            CurrentState = State.ATTACK;
            AttackEndTime = Time.time + CurrentSkill.Duration;
            NextAttackTime = AttackEndTime + CurrentSkill.Cooldown;
        }
        else if (Time.time <= AttackEndTime)
            CurrentState = State.ATTACK;
        else
            CurrentState = State.MOVE;
    }

    public override void Attack()
    {
        CurrentSkill.UseSkill(this, player);
    }
}
