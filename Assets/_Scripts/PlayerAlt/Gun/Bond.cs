using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : AGun
{

	public Bond ()
	{
		TimeBetweenshots = 5f;
		Ammo = int.MaxValue;
		Bullet = new  BondBullet ();
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
