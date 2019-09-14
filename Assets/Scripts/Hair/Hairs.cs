using System.Collections.Generic;
using UnityEngine;

public class Hairs : MonoBehaviour
{
	[SerializeField]
	Transform player = default;
	[SerializeField]
	GameObject nodePrefab = default;
	[SerializeField]
	[Range(0f, 1f)]
	float pow = 0.6f;

	LineRenderer lineRenderer;

	[SerializeField]
	int points = 8;

	List<Transform> nodes = new List<Transform>();

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();

		GameObject go = Instantiate(nodePrefab, player.position + Vector3.down * 0.5f, Quaternion.identity, transform);
		nodes.Add(go.transform);
	}

	private void Update()
	{
		for (int i = 0; i < points; i++)
		{
			lineRenderer.SetPosition(i, nodes[i].position);
		}
	}

	void GenerateNode()
	{

	}

	public void AddNode()
	{

	}

	public void RemoveNode()
	{

	}

	public void Attack(Vector3 force)
	{
		for (int i = 0; i < nodes.Count; i++)
		{
			nodes[i].GetComponent<Rigidbody2D>().AddForce(force * Mathf.Pow(pow, i));
		}
		
	}
}
