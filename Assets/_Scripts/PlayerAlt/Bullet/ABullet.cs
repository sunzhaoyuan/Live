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


	void Update ()
	{
		transform.Translate (Vector3.forward * this.Speed * Time.deltaTime);
	}
}
