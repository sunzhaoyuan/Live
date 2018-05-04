using UnityEngine;

public class FollowCamera : MonoBehaviour
{

	public Transform target;
	[Space]
	public float smoothness = 10f;
	[Range (-200f, 200f)]
	public float x;
	[Range (-200f, 200f)]
	public float y;
	[Range (-200f, 200f)]
	public float z;
	//	public Vector3 offset;

	void LateUpdate ()
	{
		if (target == null)
			return;
		Vector3 offset = new Vector3 (x, y, z);
		Vector3 desiredPosition = target.position + offset;
		//Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothness * Time.deltaTime);
		//smoothedPosition.y = y;
		transform.position = desiredPosition;

		transform.LookAt (target);
	}
}
