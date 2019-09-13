using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
	public Transform upperHair;
	public float maxDistance = 1f;

	[SerializeField]
	float yeetForce;

	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Vector3 distance = upperHair.position - transform.position;
		float magnitude = distance.magnitude;
		if (magnitude > maxDistance)
		{
			rb.AddForce(distance * (magnitude - 1) * yeetForce * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
