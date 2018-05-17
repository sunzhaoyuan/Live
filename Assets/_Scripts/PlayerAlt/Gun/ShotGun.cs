using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : AGun
{

	void Start()
	{
		//Bullet=new ShotGunBullet();
		TimeBetweenshots = .5f;
		Name = "ShotGun";
		TotalAmmo = 100;
		Ammo = MagazineCap = 10;
	}

	public override void Fire (Player player)
	{
		if (Ammo == 0) {
			player.gunfire.SetActive (false);
			player.bulleteffet.SetActive (false);
		}
	
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
			Vector3 Face=player.transform.rotation.eulerAngles;
			Quaternion FaceMid = Quaternion.Euler (Face);
			Quaternion FaceLeft = Quaternion.Euler (Face.x, Face.y + 30f, Face.z);
			Quaternion FaceRight = Quaternion.Euler (Face.x, Face.y - 30f, Face.z);


			ABullet bullet = Instantiate (Bullet, player.gunfire.transform.position, player.transform.rotation);
			ABullet bullet1 = Instantiate (Bullet, player.gunfire.transform.position, FaceLeft);
			ABullet bullet2 = Instantiate (Bullet, player.gunfire.transform.position,FaceRight);
			player.gunfire.SetActive (true);
			player.bulleteffet.SetActive(true);
			Ammo--;
		}

	}

}
