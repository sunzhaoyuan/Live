using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
	IDLE,
	MOVE,
	ATTACK,
	DIED
}

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
	public GameObject player;

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

	protected void EnemyLookAt (float yRotationOffset)
	{
		Vector3 relativePos = player.transform.position - Position;
		relativePos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		rotation.eulerAngles -= new Vector3 (0, yRotationOffset, 0);
		transform.rotation = rotation;
	}

	protected void EnemyMove (float distance)
	{
		if (Mathf.Abs (Vector3.Distance (Position, player.transform.position)) <= distance)
			return;
		Vector3 direction = Position - player.transform.position;
		direction.y = 0;
		direction.Normalize ();
		Position -= direction * Speed * Time.deltaTime;
	}
}
