using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : AGun
{

	public ShotGun ()
	{
//		Bullet;
		TimeBetweenshots = .1f;
		Name = "ShotGun";
		TotalAmmo = 200;
		Ammo = MagazineCap = 25;
	}
}
