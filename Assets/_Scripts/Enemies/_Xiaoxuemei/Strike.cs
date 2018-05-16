using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : ASkill
{

	public Strike ()
	{
		Name = "Strike";
		Damage = 20f;
		Duration = 1f;
		Cooldown = 1f;
	}

	public override void UseSkill (AEnemy enemy, Player player)
	{
		//Debug.Log ("Strike");
		enemy.EnemyMove (100f);
	}
}
