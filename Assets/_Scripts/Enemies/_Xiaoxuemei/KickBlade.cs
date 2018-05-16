using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the "Gun" of Xiaoxuemei's BackKick Skill
/// </summary>
public class KickBlade : AGun
{

	public KickBlade ()
	{
		Name = "KickBlade";
	}

	public void FireBlade (Xiaoxuemei x)
	{
		ABullet KickBladeBullet = Instantiate (Bullet, x.transform.position, x.transform.rotation);
	}
}
