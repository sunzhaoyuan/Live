using UnityEngine;

public class FollowCamera : MonoBehaviour
{

	public Transform target;
	[Space]
	public float smoothness = 10f;
	[Range (3f, 15f)]
	public float x;
	[Range (3f, 15f)]
	public float y;
	[Range (3f, 15f)]
	public float z;
	//	public Vector3 offset;

	void LateUpdate ()
	{
		Vector3 offset = new Vector3 (x, y, z);
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothness * Time.deltaTime);
		transform.position = smoothedPosition;

		transform.LookAt (target);
	}
}
