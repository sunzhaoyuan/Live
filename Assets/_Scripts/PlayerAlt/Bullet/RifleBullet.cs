using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : ABullet
{

	protected override void Update()
	{
        base.Update();
		Damage = 10f;
		Speed = 80f;
	}

}
