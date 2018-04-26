using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	[Header("Set in Inspector")]

 //   Vector3 dashTarget;
    float dashRadius = 3f;
	bool isRunning=false;
	bool isAiming=false;
	private float runSpeed=0.3f; 
	private float WalkSpeed=0.1f;
	private Transform thisTransform;
	private MeshRenderer mr;
    public GunControl theGun;
	public BondControl theBond;
	public bool isConnecting=true;//to be changed
	public GameObject connectingEnemy;

	public float MaxHP = 100;
	public float CurrentHP = 100;
    
	// Use this for initialization
	void Start () {
		thisTransform = transform;
		mr = thisTransform.GetComponent<MeshRenderer> ();
		connectingEnemy = GameObject.Find ("Aniki");
	}

	// Update is called once per frame
	void Update () {

        
		//input from left joystick
        Vector3 inputDirectionL = Vector3.zero;
        inputDirectionL.x = Input.GetAxis("Horizontal");
        inputDirectionL.z = Input.GetAxis("Vertical");
        
       //detect isRunning or not
		if (inputDirectionL.magnitude > 0.8) {
			isRunning = true;	
		} else {
			isRunning = false;
		}

		//input from right joystick
		Vector3 inputDirectionR = Vector3.zero;
		inputDirectionR.x = Input.GetAxis("FacingH");
		inputDirectionR.z = Input.GetAxis("FacingV");

		//detect aiming or not
		if (inputDirectionR.magnitude > 0.3) {
			isAiming = true;	
		} else {
			isAiming = false;
		}

		//move the player
		inputDirectionL.Normalize ();
		if (!isAiming && isRunning&&!theGun.isFiring) {//just running
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
        if (Input.GetKeyDown("joystick button 1"))
        {
            Vector3 gg = inputDirectionL;
            gg.Normalize();
			thisTransform.position = thisTransform.position + dashRadius * gg;

        }

		//shoot bullet
        if (Input.GetKeyDown("joystick button 7"))
        {
            theGun.isFiring = true;
			isAiming = true;
        }
        if(Input.GetKeyUp("joystick button 7"))
        {
            theGun.isFiring = false;
        }

		//shoot bond
		if (Input.GetKeyDown("joystick button 6"))
		{
			if (isConnecting) {
				isConnecting = false;
			}
			theBond.isFiring = true;
			isAiming = true;

		}
		if(Input.GetKeyUp("joystick button 6"))
		{
			theBond.isFiring = false;
		}
		if (isConnecting) {
			DrawBond ();
		}



    }
	void DrawBond(){
		GameObject myBond = new GameObject ();
		myBond.transform.position = thisTransform.position;
		myBond.AddComponent<LineRenderer> ();
		LineRenderer bondRenderer = myBond.GetComponent<LineRenderer> ();
		bondRenderer.material = new Material(Shader.Find("Standard"));
		bondRenderer.startWidth = 0.1f;
		bondRenderer.endWidth = 0.1f;

		bondRenderer.SetPositions(new Vector3[]{thisTransform.position, 
			this.connectingEnemy.transform.transform.position});
		GameObject.Destroy (myBond, 0.03f);
	}

	void OnTriggerEnter (Collider collider)
	{
		string tag = collider.tag;

		switch (tag)
		{
			case "Enemy":
				Debug.Log("Player.OnTriggerEnter: enemy");
				AEnemy enemy = collider.gameObject.GetComponentInParent<AEnemy>();
				ASkill skill = enemy.CurrentSkill;
				float damage = skill.Damage;
				Debug.Log("Player HP -= " + damage);
				CurrentHP -= damage;
				Debug.Log("Player::CurrentHP " + CurrentHP);
				break;
			default:
				break;
		}
	}

    }

