using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : AGun
{

	public Bond ()
	{
		TimeBetweenshots = 5f;
		Ammo = int.MaxValue;
//		Bullet = new  BondBullet ();
	}

}
