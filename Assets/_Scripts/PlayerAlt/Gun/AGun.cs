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
	public void Fire (Player player)
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
