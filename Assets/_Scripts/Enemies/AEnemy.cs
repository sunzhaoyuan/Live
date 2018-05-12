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
	public string Name = "unknown";
	public float CurrentHP = 0;
	public float MaxHP = 0;
	public float NextAttackTime = 0f;
	public float AttackEndTime = 0f;
	public Dictionary<string, List<ASkill>> Skills;
	public ASkill CurrentSkill;
	public float Speed = 0;
	public float closeRange = -1;
	public float midRange = -1;
	public float farRange = -1;
	public float WeakDuration;
	public float WeakStartTime;
	public State CurrentState;
	public bool IsWeak = false;
	public bool IsDead = false;
	public float deadAnimDuration;

	public bool CanDealDamage = false;

	public ABuff Buff;

	/// IsAnimator needs to be called before Animation and Animator 
	/// are initialized (before Start()) !!!!!
	public bool IsAnimator;
	public Animation Animation;
	public Animator Animator;
	public string LastAnimState = "";

	[Header ("DON'T Change Player")]
	public Player player;

	public Vector3 Position {
		get { return transform.position; }
		set { transform.position = value; }
	}


	/// <summary>
	/// player is initialized by GameObject.Find method
	/// because of the issue of prefab (details in RefreshBoss.cs)
	/// </summary>
	protected virtual void Awake ()
	{
		player = GameObject.Find ("Player").GetComponent<Player> ();
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
	public void EnemyLookAt ()
	{
		Vector3 relativePos = player.transform.position - Position;
		relativePos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		transform.rotation = rotation;
	}

	/// <summary>
	/// Move the Enemy
	/// </summary>
	/// <param name="distance">Distance.</param>
	public void EnemyMove (float speed)
	{
		gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}

	/// <summary>
	/// Decides the state.
	/// </summary>
	public virtual void DecideState ()
	{
		if (CurrentHP <= 0f) {
			CurrentState = State.DIED;
			return;
		}

		if (Time.time >= NextAttackTime) { //begin attack

			float distance = Mathf.Abs (Vector3.Distance (Position, player.transform.position));
			bool canAttack = false;
			string attackRange = null;
			if (0f <= distance && distance <= closeRange) {
				canAttack = true;
				attackRange = "close";
			} else if (closeRange <= distance && distance <= midRange) {
				canAttack = true;
				attackRange = "mid";
			} else if (midRange <= distance && distance <= farRange) {
				canAttack = true;
				attackRange = "far";
			}
			if (canAttack) {
				System.Random ran = new System.Random ();
				List<ASkill> skills = Skills [attackRange];
				int skillNum = ran.Next (skills.Count);
				CurrentSkill = skills [skillNum];
				CurrentState = State.ATTACK;
				AttackEndTime = CurrentSkill.Duration + Time.time;
				NextAttackTime = AttackEndTime + CurrentSkill.Cooldown; //随便设的
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
	public virtual void Attack ()
	{

		if (IsAnimator) {
			
		} else {
			//Animation.Play (CurrentSkill.AnimName);
		}
	}

	void Start ()
	{
		if (IsAnimator) {
			Animator = GetComponent<Animator> ();
		} else {
			Animation = GetComponent<Animation> ();
		}	
//		Debug.Log ("IsAnimator::" + IsAnimator);
		Debug.Log (player.name);
		CurrentSkill = new EmptySkill ();
	}

	void Update ()
	{
		if (player != null)
			DecideState ();
		else
			CurrentState = State.IDLE;
		switch (CurrentState) {

		case State.IDLE:
			CanDealDamage = false;
			break;

		case State.MOVE:
			EnemyLookAt ();
			EnemyMove (Speed);
			CanDealDamage = false;
			CurrentSkill = new EmptySkill ();
			if (IsAnimator) {
				Animator.SetBool ("IsRun", true);
			} else {
				Animation.Play ("Walk");
			}
			break;

		case State.ATTACK:
			Attack ();
			break;

		case State.DIED:
			CanDealDamage = false;
			Die ();
			break;

		default:
			break;
		}
//		Debug.Log (Animator.GetBool ());
		
	}

	/// <summary>
	/// Every Subclasses need to inherient Die(). 
	/// Small Boss: Destroy(gameObject)
	/// Big Boss: Rotate. (See Aniki.cs)
	/// </summary>
	public virtual void Die ()
	{
		Destroy (this.gameObject);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="collider"></param>
	void OnTriggerEnter (Collider collider)
	{
		string tag1 = collider.tag;
		switch (tag1) {
		case "Bullet":

			ABullet bullet = collider.gameObject.GetComponent<ABullet> ();
			CurrentHP -= bullet.Damage;
			Destroy (collider.gameObject);
			break;

		case "BondBullet":
			player.IsConnecting = true;
			player.ConnectingEnemy = this;
			if (Buff != null) {
				Buff.SetBuff (player);
				player.Buff = Buff;
			}
			Destroy (collider.gameObject);
			break;

		default :
			break;
		}
	}

	public void ClearAnimState ()
	{
		Animator.SetBool (LastAnimState, false);
	}

	public void DeactivateAnimState (string AnimState)
	{
		Animator.SetBool (AnimState, false);
	}

	public void ActivateAnimState (string AnimState)
	{
		Animator.SetBool (AnimState, true);
	}
}