using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public bool IsRunning = false;
	public bool IsAiming = false;
	public bool IsFiring = false;

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
	public int FlashNumber = 0;
	public float TimeNextFlash = 0f;
	public float FlashCD = 5f;

	public float throwForce = 300f;
	public GameObject grenadePrefab;

    public GameObject DodgeFlash;
    float delayTime = 0.2f;

	public Bond BondPrefab;
	public Rifle RiflePrefab;
	public ShotGun ShotGunPrefab;
	public AGun Bond;
	public AGun PrimaryGun;
	public AGun SecondaryGun;
	public GameObject gunfire;
	public GameObject bulleteffet;

	// UI
	public Image uitHPbar;
	public Text uitBuff;


	void Start ()
	{
		Bond = (AGun)Instantiate (BondPrefab);
		PrimaryGun = (AGun)Instantiate (RiflePrefab);
		SecondaryGun = (AGun)Instantiate (ShotGunPrefab);
		CurrentHP = MaxHP;
		//Gun1 = 1;
		//Gun2 = 0;

	}

	void Update ()
	{

		SetDirections ();
		MoveAndAim ();
	//	Debug.Log ("Run:"+IsRunning);
	//	Debug.Log ("Aim:"+IsAiming);

		UpdateGrenade ();
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

		//Update HP UI
		uitHPbar.fillAmount = CurrentHP / 100f;
		uitBuff.text = "Buff: " + Buff.Name;

	}

	void UpdateGrenade ()
	{
		if (Time.time >= TimeNextFlash) {
			if (FlashNumber < 3) {
				FlashNumber++;
				TimeNextFlash = Time.time + FlashCD;
			}
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
		} 
		else {
			IsAiming = false;
		//	transform.rotation=Quaternion.Euler (0f, Mathf.Atan2 (-MovingDirection.z, MovingDirection.x) / Mathf.PI * 180, 0f);
		//	FacingDirection = MovingDirection;
		}
		
		MovingDirection.Normalize ();
	}

	void MoveAndAim ()
	{
		Quaternion MoveRot = Quaternion.Euler (0f, Mathf.Atan2 (MovingDirection.x, MovingDirection.z) / Mathf.PI * 180, 0f);

		if (!IsAiming && IsRunning && !IsFiring) {//just running
			transform.position += MovingDirection * RunSpeed;
			transform.rotation = MoveRot;
			FacingDirection = MovingDirection;
		} else if (IsRunning && IsFiring && !IsAiming) {
			transform.rotation = MoveRot;
			transform.position += MovingDirection * WalkSpeed;
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
		if (Input.GetKey ("joystick button 7")|| Input.GetKey("space")) { //r2
			IsAiming = true;
            IsFiring = true;
            PrimaryGun.Fire (this);
		} else {
			IsFiring = false;
			this.gunfire.SetActive (false);
			this.bulleteffet.SetActive (false);

		}


		//shoot bond
		if (Input.GetKey ("joystick button 6") && !IsConnecting) {
			Bond.Fire (this);
		} else if (Input.GetKey ("joystick button 6")) {
			DrawBond ();
		} else {
			IsConnecting = false;
			ConnectingEnemy = null;
			Buff = new EmptyBuff (); 
		}
	}

	void UseSkill ()
	{
		if (Input.GetKeyDown ("joystick button 4")||Input.GetKeyDown(KeyCode.B )) {
			TimeNextSkill += 3f;
			ThrowGrenade ();
		} else if (Input.GetKeyDown ("joystick button 5")) {
			TimeNextSkill += 1f;
			PrimaryGun.Reload ();
		} else if (Input.GetKeyDown ("joystick button 1")|| Input.GetKeyDown(KeyCode.A)) {
			if (FlashNumber >= 0) {
				Dodge ();
				FlashNumber--;
			}
		} else if (Input.GetKeyDown ("joystick button 2")) {
			TimeNextSkill += 1f;
			SwitchGun ();
		}
	}

	void ThrowGrenade ()
	{
        //Vector3 initialposition = new Vector3(transform.position.x, transform.position.y-2f, transform.position.z);
		GameObject grenade = Instantiate (grenadePrefab, transform.position, transform.rotation);
		Rigidbody rb = grenade.GetComponent<Rigidbody> ();
		Vector3 gg = FacingDirection;
		gg.Normalize ();
        rb.useGravity = true;
		rb.AddForce(transform.forward*50f, ForceMode.Impulse);
        
	}

	void Dodge ()
	{
        Instantiate(DodgeFlash, transform.position, transform.rotation);
        gameObject.SetActive(false);
        
		Vector3 moveDir = MovingDirection;
		moveDir.Normalize ();
		transform.position = transform.position + DashRadius * moveDir;
       
        Invoke("DelayDodge",delayTime);
        
        Destroy(DodgeFlash);

    }

    void DelayDodge()
    {
        Instantiate(DodgeFlash, transform.position, transform.rotation);
        gameObject.SetActive(true);
    }

	void DrawBond ()
	{
		IsAiming = false;
		GameObject myBond = new GameObject ();
		myBond.transform.position = transform.position;
		myBond.AddComponent<LineRenderer> ();
		LineRenderer bondRenderer = myBond.GetComponent<LineRenderer> ();
		bondRenderer.material = new Material (Shader.Find ("Particles/Additive"));
		bondRenderer.startWidth = .5f;
		bondRenderer.endWidth = .5f;
		bondRenderer.startColor = Color.red;
		bondRenderer.endColor = Color.red;

		bondRenderer.SetPositions (new Vector3[] {transform.position, 
			this.ConnectingEnemy.transform.position
		});
		GameObject.Destroy (myBond, 0.05f);
	}

	void Die ()
	{
		Destroy (this.gameObject);
	}

	void SwitchGun ()
	{
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
			float damage = enemySkill.Damage;
			CurrentHP -= damage;
			if (CurrentHP <= 0)
				Die ();
			break;

		case "Boss":
			AEnemy boss = collider.gameObject.GetComponentInParent<AEnemy> ();
			ASkill bossSkill = boss.CurrentSkill;
			float d = bossSkill.Damage;
			CurrentHP -= d;
			if (CurrentHP <= 0)
				Die ();
			break;

		default:
			break;
		}
	}
}
