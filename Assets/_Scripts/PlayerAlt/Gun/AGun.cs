using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGun : MonoBehaviour
{

	//	public bool IsFiring = false;
	public string Name;
	public float TimeBetweenshots;
	public float TimeNextShot = .5f;

	public int TotalAmmo;
	public int MagazineCap;
	public int Ammo;

	//public GameObject gunfire;

	public ABullet Bullet;


	//	void Update ()
	//	{
	//		if (IsFiring && Ammo > 0 && Time.time >= TimeNextShot) {
	//			Fire ();
	//		}
	//	}

	//	public AGun ()
	//	{
	//		Ammo = MagazineCap;
	//	}


	/// <summary>
	/// Fire this instance.
	/// </summary>
	public virtual void Fire (Player player){
		
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
