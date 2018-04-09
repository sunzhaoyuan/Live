using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract enemy class. All enemies classes should extend it.
/// </summary>
public class AEnemy : MonoBehaviour
{

	private bool _IsWeak = false;

	public enum State
	{
		IDLE,
		MOVE,
		ATTACK,
		DIED
	}


	public string Name {
		get;
	}

	public float MaxHP {
		get;
	}

	public float HP {
		get;
		set;
	}

	public float NextAttackTime {
		get;
		set;
	}

	public Dictionary<string, ASkill> Skills {
		get;
		set;
	}

	public ASkill CurrentSkill {
		get;
		set;
	}

	public float Speed {
		get;
		set;
	}

	public Vector3 Position {
		get { return transform.position; }
		set { transform.position = value; }
	}

	public float WeakDuraction {
		get;
		set;
	}

	public float WeakStartTime {
		get;
		set;
	}

	public State CurrentState {
		get;
		set;
	}

	public bool IsWeak {
		get;
		set;
	}

	/// <summary>
	/// This method deal with damage taken from the bullet
	/// </summary>
	/// <param name="int damage">
	/// HP -= damage;
	/// if (IsWeak) { HP -= 0.3*MaxHP; CurrentState = State.IDLE; }
	/// </param>.
	public virtual void DamageTaken ()
	{
		
	}
}
