using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungKid : AEnemy
{

	// Need a field for Buff

	public YoungKid ()
	{
		Name = "YoungKid";
//		CurrentHP = 100f;
		MaxHP = 100f;
		Speed = 5f;
		CurrentState = State.IDLE;
		Skills = new Dictionary<string, List<ASkill>> {
			{ "close", new List<ASkill>{ new Stab ()  } } 
		};

	}


	void Start ()
	{
		CurrentHP = 100f;
	}


	void Update ()
	{
		DecideState ();
		switch (CurrentState) {

		case State.IDLE:
			break;

		case State.MOVE:
			EnemyLookAt (90f);
			EnemyMove (2f);
			break;

		case State.ATTACK:
			Attack ();
			break;

		case State.DIED:
			Die ();
			break;

		default:
			break;
		}
	}
}
