using System.Collections.Generic;
using UnityEngine;

public class Hairs : MonoBehaviour
{
	[SerializeField]
	List<Transform> nodes = default;
	[SerializeField]
	[Range(0f, 1f)]
	float pow = 0.6f;

	LineRenderer lineRenderer;

	int points = 8;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		for (int i = 0; i < points; i++)
		{
			lineRenderer.SetPosition(i, nodes[i].position);
		}
	}

	public void Attack(Vector3 force)
	{
		for (int i = 0; i < nodes.Count; i++)
		{
			nodes[i].GetComponent<Rigidbody2D>().AddForce(force * Mathf.Pow(pow, i));
		}
		
	}
}
