using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a bullet gameobject
/// </summary>
public class ABullet : MonoBehaviour
{

	public float Speed;
	public float Damage;
	public ABullet Bullet;

	protected virtual void Update ()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * this.Speed;
	}
		
}
