﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class ASkill : MonoBehaviour
{
    public string Name;
    public float Damage;
    public float Duration;
    public float Cooldown;
    
	//public string AnimName { get; }

	public void ActivateCollider (bool Activated, Collider collider)
	{
		collider.enabled = Activated;
	}

    public virtual void UseSkill(AEnemy enemy, Player player)
    {
        return;
    }
	

}
