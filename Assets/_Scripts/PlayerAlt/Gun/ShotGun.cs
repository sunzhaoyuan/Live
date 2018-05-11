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
			Vector3 Face=player.transform.rotation.eulerAngles;
			Quaternion FaceMid = Quaternion.Euler (Face);
			Quaternion FaceLeft = Quaternion.Euler (Face.x, Face.y + 30, Face.z);
			Quaternion FaceRight = Quaternion.Euler (Face.x, Face.y - 30, Face.z);


			ABullet bullet = Instantiate (Bullet, player.transform.position, FaceMid);
			ABullet bullet1 = Instantiate (Bullet, player.transform.position, FaceLeft);
			ABullet bullet2 = Instantiate (Bullet, player.transform.position,FaceRight);


			Ammo--;
		}
	}

}
