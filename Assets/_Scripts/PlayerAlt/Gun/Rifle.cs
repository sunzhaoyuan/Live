using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : AGun
{

	public Rifle ()
	{
//		Bullet = GameObject.Find ("Bullet");
//		Bullet;
		TimeBetweenshots = .1f;
		Name = "Rifle";
		TotalAmmo = 400;
		Ammo = MagazineCap = 25;
		//Bullet = new RifleBullet ();
	}
}
