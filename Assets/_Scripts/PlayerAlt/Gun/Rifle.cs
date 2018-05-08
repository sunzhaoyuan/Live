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
		TotalAmmo = 300;
		Ammo = MagazineCap = 30;

	}
	public override void Fire (Player player)
	{
		Debug.Log("firing");
		Debug.Log (Ammo);
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
			Debug.Log("shoting");
			ABullet bullet = Instantiate (Bullet, player.transform.position, player.transform.rotation);
			Ammo--;
			Debug.Log ("AGun::Fire()");
		}
	}


}
