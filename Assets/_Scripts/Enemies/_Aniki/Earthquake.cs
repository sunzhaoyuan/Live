using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Earthquake : ASkill
{
	public Earthquake ()
	{
		Name = "Earthquake";
		Damage = 50.0f;
		Duration = 1.5f;
        Cooldown = 1f;
	}

}
