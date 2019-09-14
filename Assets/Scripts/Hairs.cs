using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairs : MonoBehaviour
{
	LineRenderer lineRenderer;

	int points = 8;

	[SerializeField]
	List<Transform> nodes;

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

	public void Attack()
	{

	}
}
