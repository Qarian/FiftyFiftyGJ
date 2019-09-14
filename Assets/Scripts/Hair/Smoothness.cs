using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothness : MonoBehaviour
{
	public List<HoldingDistance> scripts;

	private void Update()
	{
		if (scripts == null)
			return;

		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < scripts.Count; j++)
			{
				scripts[j].UpdateDistance();
			}
		}
	}
}
