using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract enemy class. All enemies classes should extend it.
/// </summary>
public class AEnemy : MonoBehaviour
{

	
	public string Name;
	public float CurrentHP;
	public float MaxHP;
	public float NextAttackTime;
	public Dictionary<string, ASkill> Skills;
	public ASkill CurrentSkill;
	public float Speed;
	public float WeakDuration;
	public float WeakStartTime;
	public State CurrentState;
	public bool IsWeak = false;


	public enum State
	{
		IDLE,
		MOVE,
		ATTACK,
		DIED
	}

	public Vector3 Position {
		get { return transform.position; }
		set { transform.position = value; }
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
