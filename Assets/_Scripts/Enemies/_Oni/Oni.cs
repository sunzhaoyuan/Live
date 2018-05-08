using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni : AEnemy
{

	public Oni ()
	{
		Name = "Oni";
		MaxHP = 100f;
		CurrentHP = MaxHP;
		Speed = 5f;
		CurrentState = State.IDLE;
		closeRange = 8f;
		deadAnimDuration = 1f;
		Buff = new EmptyBuff ();
//		CurrentSkill = new Stab ();
//		Buff = null;
		Skills = new Dictionary<string, List<ASkill>> { {"close", new List<ASkill> {new StabAlt (), new StabAlt (), new StabAlt (), new Earthquake ()
				}
			}
		};
	}


	protected override void Awake ()
	{
		base.Awake ();
		IsAnimator = true;
	}


	/// <summary>
	/// Decide Move -> (Based on distance) Decide Attack
	/// </summary>
	protected override void DecideState ()
	{
		// need to have decide move code here (before base)
		DecideMove ();
		base.DecideState ();
	}


	private void DecideMove ()
	{
		
	}

	/// <summary>
	/// stop any current animation and play die animation
	/// </summary>
	protected override void Die ()
	{
		base.Die ();
		if (Time.time == deadAnimDuration) {
			transform.Rotate (new Vector3 (0f, 0f, 90f));
		}
	}
}
