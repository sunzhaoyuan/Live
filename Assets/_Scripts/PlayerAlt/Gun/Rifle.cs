using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : AGun
{

	public Rifle ()
	{
		TimeBetweenshots = .1f;

		TotalAmmo = 400;
		MagazineCap = 25;

		Bullet = new RifleBullet ();
	}
}
