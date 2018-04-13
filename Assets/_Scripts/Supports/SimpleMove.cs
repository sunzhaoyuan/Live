using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{

	public float moveSpeed;

	void Start ()
	{
	}

	void Update ()
	{
		transform.Translate (moveSpeed * Time.deltaTime * new Vector3 (
			-Input.GetAxis ("Horizontal"), 
			0f, 
			-Input.GetAxis ("Vertical")));
	}
}
