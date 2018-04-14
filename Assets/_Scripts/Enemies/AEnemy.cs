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
	public float NextAttackTime = 0f;
	public float AttackEndTime = 0f;
	public Dictionary<string, List<ASkill>> Skills;
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

	/// <summary>
	/// Enemies always looks at the player, rotating by y by yRotationOffset.
	/// </summary>
	/// <param name="yRotationOffset">Y rotation offset.</param>
	protected void EnemyLookAt (float yRotationOffset)
	{
		Vector3 relativePos = player.transform.position - Position;
		relativePos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		rotation.eulerAngles -= new Vector3 (0, yRotationOffset, 0);
		transform.rotation = rotation;
	}


	/// <summary>
	/// Move the Enemy
	/// </summary>
	/// <param name="distance">Distance.</param>
	protected void EnemyMove (float distance)
	{
		if (Mathf.Abs (Vector3.Distance (Position, player.transform.position)) <= distance)
			return;

		Vector3 direction = Position - player.transform.position;
		direction.y = 0;
		direction.Normalize ();
		Position -= direction * Speed * Time.deltaTime;
	}


	/// <summary>
	/// Decides the state.
	/// </summary>
	protected void DecideState ()
	{
		if (CurrentHP == 0f) {
			CurrentState = State.DIED;
			return;
		}

		if (Time.time >= NextAttackTime) { //begin attack
			float distance = Mathf.Abs (Vector3.Distance (Position, player.transform.position));
			bool canAttack = false;
			string attackRange = null;
			if (0f <= distance && distance <= 2f && Skills.ContainsKey ("close")) {
				canAttack = true;
				attackRange = "close";
			} else if (2f <= distance && distance <= 8f && Skills.ContainsKey ("mid")) {
				canAttack = true;
				attackRange = "mid";
			} else if (8f <= distance && distance <= 16 && Skills.ContainsKey ("far")) {
				canAttack = true;
				attackRange = "far";
			}
			if (canAttack) {
				System.Random ran = new System.Random ();
				List<ASkill> skills = Skills [attackRange];
				int skillNum = ran.Next (skills.Count);
				CurrentSkill = skills [skillNum];

				Debug.Log ("Skill Name: " + CurrentSkill.Name);

				CurrentState = State.ATTACK;
				AttackEndTime = CurrentSkill.Duration + Time.time;
				NextAttackTime = AttackEndTime + (float)(2 + ran.NextDouble ()); //随便设的
			} else { //Cannot attack
				CurrentState = State.MOVE;
			}
		} else if (Time.time <= AttackEndTime) { // in attack animation
			CurrentState = State.IDLE;
		} else {
			CurrentState = State.MOVE;
		}
	}

	/// <summary>
	/// only play animation
	/// </summary>
	protected void Attack ()
	{
		
	}


	/// <summary>
	/// stop any current animation and play die animation
	/// </summary>
	protected void Die ()
	{
		Destroy (this.gameObject);
	}

}
