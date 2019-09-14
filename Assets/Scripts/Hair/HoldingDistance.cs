using UnityEngine;

public class HoldingDistance : MonoBehaviour
{
	public Transform target;
	public float maxDistance;

	[SerializeField]
	bool autoUpdate = false;
	[SerializeField]
	float zPos = 0f;

	private void Update()
	{
		if (autoUpdate)
			UpdateDistance();
	}

	public void UpdateDistance()
	{
		Vector2 distance = transform.position - target.position;

		if (distance.magnitude > maxDistance)
		{
			distance = Vector2.ClampMagnitude(distance, maxDistance - 0.001f);
			Vector3 newPos = (Vector2)target.position + distance;
			newPos.z = zPos;
			transform.position = newPos;
		}
	}
}
