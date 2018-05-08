using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : AGun
{

	public ShotGun ()
	{
//		
		Bullet=new ShotGunBullet();
		TimeBetweenshots = .5f;
		Name = "ShotGun";
		TotalAmmo = 100;
		Ammo = MagazineCap = 10;
	}

	public override void Fire (Player player)
	{
	
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
			Quaternion Face = player.transform.rotation;
			//Vector3 Face = player.transform.forward;



			ABullet bullet = Instantiate (Bullet, player.transform.position, Face);
			Face = Quaternion.Euler (0, 30, 0);
			ABullet bullet1 = Instantiate (Bullet, player.transform.position, Face);
			Face = Quaternion.Euler (0, -30, 0);
			ABullet bullet2 = Instantiate (Bullet, player.transform.position,Face);


			Ammo--;
		}
	}
}
