using System.Collections.Generic;
using UnityEngine;

public class Smoothness : MonoBehaviour
{
	[SerializeField]
	Transform player = default;
	[HideInInspector]
	public List<HoldingDistance> scripts;

	LineRenderer lineRenderer;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (scripts == null)
			return;

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < scripts.Count; j++)
			{
				scripts[j].UpdateDistance();
			}
		}

		lineRenderer.SetPosition(0, player.position);
		for (int i = 1; i < lineRenderer.positionCount; i++)
		{
			lineRenderer.SetPosition(i, scripts[i - 1].transform.position);
		}
	}
}
