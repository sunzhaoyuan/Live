using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverPlayerHealth : MonoBehaviour
{

	public bool IsPlayerInTrigger;
	public float RecoveryRate;
	private Player player;
    public Light light;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (IsPlayerInTrigger && player.CurrentHP < player.MaxHP) {
			Debug.Log ("Recovering");
			player.CurrentHP += RecoveryRate;
        }
	}

	/// <summary>
	/// If player enter this area (trigger), recover its health
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag.Equals ("Player")) {
			IsPlayerInTrigger = true;
            light.enabled = true;
        }
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag.Equals ("Player")) {
			IsPlayerInTrigger = false;
            light.enabled = false;
		}
	}

}
