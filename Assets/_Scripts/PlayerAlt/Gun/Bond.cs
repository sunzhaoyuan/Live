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
		
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
		
			ABullet bullet = Instantiate (Bullet, player.transform.position, player.transform.rotation);
			Ammo--;

		}
	}

}
