using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header ("Set in Inspector")]
	//public AGun[] Guns;

	//public int Gun1;
	//public int Gun2;

	[Header ("Set Dynamically")]
	public bool IsRunning = false;
	public bool IsAiming = false;

	public float DashRadius = 10f;
	public float RunSpeed = 1.5f;
	public float WalkSpeed = 0.5f;
	public Vector3 MovingDirection;
	public Vector3 FacingDirection;
	public float MaxHP = 100f;
	public float CurrentHP;
	public ABuff Buff = new EmptyBuff ();

	public int GunIndex;

	public bool IsConnecting = false;
	public AEnemy ConnectingEnemy;

	public float TimeNextSkill = 0f;

    public float throwForce = 40f;
    public GameObject grenadePrefab;

	//test
	public Bond BondPrefab;
	public Rifle RiflePrefab;
	public ShotGun ShotGunPrefab;
	public AGun Bond;
	public AGun PrimaryGun;
	public AGun SecondaryGun;

	void Start ()
	{
		Bond = (AGun)Instantiate (BondPrefab);
		PrimaryGun = (AGun)Instantiate(RiflePrefab);
		SecondaryGun = (AGun)Instantiate (ShotGunPrefab);
		CurrentHP = MaxHP;
    	//Gun1 = 1;
		//Gun2 = 0;

	}

	void Update ()
	{
		Debug.Log (PrimaryGun.Name);
		SetDirections ();
		MoveAndAim ();
		if (Time.time >= TimeNextSkill) {
			Fire ();
			UseSkill ();
		}
		if (IsConnecting && Buff.Name != "EmptyBuff") {
			DrawBond ();
		} else {
			IsConnecting = false;
			ConnectingEnemy = null;
		}

	}

	void SetDirections ()
	{
		MovingDirection.x = Input.GetAxis ("Horizontal");
		MovingDirection.z = Input.GetAxis ("Vertical");

		if (MovingDirection.magnitude > 0.8) {
			IsRunning = true;	
		} else {
			IsRunning = false;
		}

		FacingDirection.x = Input.GetAxis ("FacingH");
		FacingDirection.z = Input.GetAxis ("FacingV");
		//detect aiming or not
		if (FacingDirection.magnitude > 0.3) {
			IsAiming = true;	
		} else {
			IsAiming = false;
			transform.rotation=Quaternion.Euler (0f, Mathf.Atan2 (-MovingDirection.z, MovingDirection.x) / Mathf.PI * 180, 0f);
		}
		
		MovingDirection.Normalize ();
	}

	void MoveAndAim ()
	{
		if (!IsAiming && IsRunning) {//just running
			transform.position += MovingDirection * RunSpeed;
			Quaternion Rot = Quaternion.Euler (0f, Mathf.Atan2 (-MovingDirection.z, MovingDirection.x) / Mathf.PI * 180, 0f);
			transform.rotation = Rot;
		} else {
			transform.position += MovingDirection * WalkSpeed;
		}

		//aiming
		if (IsAiming) {
			Quaternion Rot = Quaternion.Euler (0f, Mathf.Atan2 (FacingDirection.z, FacingDirection.x) / Mathf.PI * 180, 0f);
			transform.rotation = Rot;
		}
	}

	void Fire ()
	{
		if (Input.GetKey ("joystick button 7")) { //r2
			IsAiming = true;
			PrimaryGun.Fire (this);
		} else {
			IsAiming = false;
		}


		//shoot bond
		if (Input.GetKey ("joystick button 6") && !IsConnecting) {
			Bond.Fire (this);
		} else {
			IsConnecting = false;
			ConnectingEnemy = null;
			Buff = new EmptyBuff (); 
		}
	}

	void UseSkill ()
	{
		if (Input.GetKeyDown ("joystick button 4")) {
			TimeNextSkill += 3f;
			ThrowGrenade ();
		} else if (Input.GetKeyDown ("joystick button 5")) {
			TimeNextSkill += 1f;
			PrimaryGun.Reload ();
		} else if (Input.GetKeyDown ("joystick button 1")) {
			TimeNextSkill += 3f;
			Dodge ();
		} else if (Input.GetKeyDown ("joystick button 2")) {
			TimeNextSkill += 1f;
			SwitchGun();
		}
	}

	void ThrowGrenade ()
	{
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        Vector3 gg = MovingDirection;
        gg.Normalize();
        rb.AddForce(gg * throwForce, ForceMode.VelocityChange);

    }

	void Dodge ()
	{
		Vector3 moveDir = MovingDirection;
		moveDir.Normalize ();
		transform.position = transform.position + DashRadius * moveDir;
		
	}

	void DrawBond ()
	{
		IsAiming = false;
		GameObject myBond = new GameObject ();
		myBond.transform.position = transform.position;
		myBond.AddComponent<LineRenderer> ();
		LineRenderer bondRenderer = myBond.GetComponent<LineRenderer> ();
		bondRenderer.material = new Material (Shader.Find ("Standard"));
		bondRenderer.startWidth = 0.1f;
		bondRenderer.endWidth = 0.1f;

		bondRenderer.SetPositions (new Vector3[] {transform.position, 
			this.ConnectingEnemy.transform.position
		});
		GameObject.Destroy (myBond, 0.01f);
	}

	void Die ()
	{
		Destroy (this.gameObject);
	}

	void SwitchGun(){
		AGun TempGun = PrimaryGun;
		PrimaryGun = SecondaryGun;
		SecondaryGun = TempGun;
	}

	void OnTriggerEnter (Collider collider)
	{
		string tag = collider.tag;

		switch (tag) {
	
		case "Enemy":
			AEnemy enemy = collider.gameObject.GetComponentInParent<AEnemy> ();
			ASkill enemySkill = enemy.CurrentSkill;
			if (enemySkill == null)
				break;
			float damage = enemySkill.Damage;
			CurrentHP -= damage;
			if (CurrentHP <= 0)
				Die ();
			break;

		default:
			break;
		}
	}
}
