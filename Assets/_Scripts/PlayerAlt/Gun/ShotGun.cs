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
		Debug.Log("firing");
		Debug.Log (Ammo);
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
			Debug.Log("shoting");
			Vector3 Face = player.transform.forward;
			ABullet bullet = Instantiate (Bullet, player.transform.position, player.transform.rotation);
			player.transform.rotation = Quaternion.AngleAxis (10, Face);
			ABullet bullet1 = Instantiate (Bullet, player.transform.position, player.transform.rotation);
			player.transform.rotation=  Quaternion.AngleAxis (-10, Face);
			ABullet bullet2 = Instantiate (Bullet, player.transform.position, player.transform.rotation);
			Ammo--;

			Debug.Log ("AGun::Fire()");
		}
	}
}
