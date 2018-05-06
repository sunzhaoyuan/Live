using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class ASkill : MonoBehaviour
{

	public string Name { get; set; }

	public float Damage { get; set; }

	public float Duration { get; set; }

	public void ActivateCollider (bool Activated, Collider collider)
	{
		collider.enabled = Activated;
	}

	public float Cooldown ()
	{
		return 0f;
	}

	public string AnimName { get; }
}
