using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{

	public float moveSpeed;

	void Start ()
	{
	}

	void Update ()
	{
		transform.Translate (moveSpeed * Time.deltaTime * new Vector3 (
			-Input.GetAxis ("Horizontal"), 
			0f, 
			-Input.GetAxis ("Vertical")));
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
				Debug.Log("CurrentSkill::" + skill);
				float damage = skill.Damage;
				Debug.Log("Player HP -= " + damage);
				// HP -= damage
				break;
			default:
				break;
		}
	}
}
