using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGun : MonoBehaviour
{

	//	public bool IsFiring = false;

	public float TimeBetweenshots;
	public float TimeNextShot = .5f;

	public int TotalAmmo;
	public int MagazineCap;
	public int Ammo;

	public ABullet Bullet;


	//	void Update ()
	//	{
	//		if (IsFiring && Ammo > 0 && Time.time >= TimeNextShot) {
	//			Fire ();
	//		}
	//	}

	void Start ()
	{
		Ammo = MagazineCap;
	}


	/// <summary>
	/// Fire this instance.
	/// </summary>
	public void Fire ()
	{
		if (Ammo > 0 && Time.time >= TimeNextShot) {
			TimeNextShot = Time.time + TimeBetweenshots;
			ABullet bullet = Instantiate (Bullet, transform.position, transform.rotation) as ABullet;
			Ammo--;
		}
	}


	/// <summary>
	/// Keep the left ammo
	/// </summary>
	public void Reload ()
	{
		if (TotalAmmo + Ammo <= MagazineCap) {
			TotalAmmo = 0;
			Ammo += TotalAmmo;
		} else {
			TotalAmmo -= MagazineCap - Ammo;
			Ammo = MagazineCap;
		}
	}
}
