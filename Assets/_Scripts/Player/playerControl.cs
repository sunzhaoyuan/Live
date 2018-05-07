using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

	[Header ("Set in Inspector")]

	//   Vector3 dashTarget;
    public float dashRadius = 10f;
	bool isRunning = false;
	bool isAiming = false;
	public float runSpeed = 1.5f;
	public float WalkSpeed = 0.5f;
	public Transform thisTransform;
	public MeshRenderer mr;
	public GunControl theGun;
	public BondControl theBond;
	public bool isConnecting = false;
	//to be changed
	public AEnemy connectingEnemy;

	public float MaxHP = 100;
	public float CurrentHP = 100;

    public float throwForce = 40f;
    public GameObject grenadePrefab;

	public ABuff Buff = new EmptyBuff ();
    
	// Use this for initialization
	public static playerControl instance;

	public playerControl Instance ()
	{
		if (this == null)
			return new playerControl ();
		return this;
	}

	public playerControl ()
	{
	}

	void Start ()
	{
		thisTransform = transform;
		mr = thisTransform.GetComponent<MeshRenderer> ();
//		Buff = new EmptyBuff ();
	}

	// Update is called once per frame
	void Update ()
	{

        
		//input from left joystick
		Vector3 inputDirectionL = Vector3.zero;
		inputDirectionL.x = Input.GetAxis ("Horizontal");
		inputDirectionL.z = Input.GetAxis ("Vertical");
        
		//detect isRunning or not
		if (inputDirectionL.magnitude > 0.8) {
			isRunning = true;	
		} else {
			isRunning = false;
		}

		//input from right joystick
		Vector3 inputDirectionR = Vector3.zero;
		inputDirectionR.x = Input.GetAxis ("FacingH");
		//Debug.Log(inputDirectionR.x);
		inputDirectionR.z = Input.GetAxis ("FacingV");
		//detect aiming or not
		if (inputDirectionR.magnitude > 0.3) {
			isAiming = true;	
		} else {
			isAiming = false;
		}

		//move the player
		inputDirectionL.Normalize ();
		if (!isAiming && isRunning && !theGun.isFiring) {//just running
			// print("just running");
			thisTransform.position += inputDirectionL * runSpeed;
			Quaternion Rot = Quaternion.Euler (0f, Mathf.Atan2 (-inputDirectionL.z, inputDirectionL.x) / Mathf.PI * 180, 0f);
			thisTransform.rotation = Rot;
		} else {
			thisTransform.position += inputDirectionL * WalkSpeed;
		}

		//aiming
		if (isAiming) {
			//  print("is Aiming");
			Quaternion Rot = Quaternion.Euler (0f, Mathf.Atan2 (inputDirectionR.z, inputDirectionR.x) / Mathf.PI * 180, 0f);
			thisTransform.rotation = Rot;
		}

		//dodge (use x button)
		// TODO: add effect like the destroying castle prototype.
		// TODO: add a cooldown recorder to limit the usage of flash.
		if (Input.GetKeyDown ("joystick button 1")) {
			Vector3 gg = inputDirectionL;
			gg.Normalize ();
			thisTransform.position = thisTransform.position + dashRadius * gg;

		}

		//shoot bullet
		if (Input.GetKeyDown ("joystick button 7")) {
			theGun.isFiring = true;
			isAiming = true;
		}
		if (Input.GetKeyUp ("joystick button 7") ) {
			theGun.isFiring = false;
		}

		//shoot bond
		if (Input.GetKeyDown ("joystick button 6")) {
			theBond.isFiring = true;
			isAiming = true;

		}
		if (Input.GetKeyUp ("joystick button 6")) {
			theBond.isFiring = false;
			isConnecting = false;
			connectingEnemy = null;
			//Buff.RemoveBuff (this);
			//Buff = new EmptyBuff ();
			
		}
		if (isConnecting && Buff.Name != "EmptyBuff") {
			DrawBond ();
		} else {
			isConnecting = false;
			connectingEnemy = null;
		}

        if (Input.GetKey(KeyCode.B))
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            Vector3 gg = inputDirectionL;
            gg.Normalize();
            rb.AddForce(gg * throwForce, ForceMode.VelocityChange);
        }



	}

	void DrawBond ()
	{
		theBond.isFiring = false;
		isAiming = false;
		GameObject myBond = new GameObject ();
		myBond.transform.position = thisTransform.position;
		myBond.AddComponent<LineRenderer> ();
		LineRenderer bondRenderer = myBond.GetComponent<LineRenderer> ();
		bondRenderer.material = new Material (Shader.Find ("Standard"));
		bondRenderer.startWidth = 0.1f;
		bondRenderer.endWidth = 0.1f;

		bondRenderer.SetPositions (new Vector3[] {thisTransform.position, 
			this.connectingEnemy.transform.transform.position
		});
		GameObject.Destroy (myBond, 0.03f);
	}

	void Die ()
	{
		Destroy (this.gameObject);
	}


	void OnTriggerEnter (Collider collider)
	{
		string tag = collider.tag;

		switch (tag) {
		case "Enemy":
			//Debug.Log ("Player.OnTriggerEnter: enemy");
			AEnemy enemy = collider.gameObject.GetComponentInParent<AEnemy> ();
			ASkill enemySkill = enemy.CurrentSkill;
			//Debug.Log (enemySkill);
			if (enemySkill == null)
				break;
			float damage = enemySkill.Damage;
			//Debug.Log ("Player HP -= " + damage);
			CurrentHP -= damage;
			if (CurrentHP <= 0)
				Die ();
			//Debug.Log ("Player::CurrentHP " + CurrentHP);
			break;
		default:
			break;
		}
	}

}

