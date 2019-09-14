using UnityEngine;

public class HoldingDistance : MonoBehaviour
{
	public Transform target;
	public float maxDistance;

	public void UpdateDistance()
	{
		Vector3 distance = transform.position - target.position;

		if (distance.magnitude > maxDistance)
		{
			distance = Vector3.ClampMagnitude(distance, maxDistance - 0.001f);
			transform.position = target.position + distance;
		}
	}
}
