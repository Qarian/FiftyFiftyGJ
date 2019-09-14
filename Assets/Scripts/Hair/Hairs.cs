using System.Collections.Generic;
using UnityEngine;

public class Hairs : MonoBehaviour
{
	[SerializeField]
	Transform player = default;
	[SerializeField]
	GameObject nodePrefab = default;
	[Space]
	[SerializeField]
	[Range(0f, 1f)]
	float pow = 0.6f;
	[SerializeField]
	float firstNodeDistance = 0.3f;

	[SerializeField]
	KeyCode addNode = KeyCode.I;
	[SerializeField]
	KeyCode removeNode = KeyCode.K;

	LineRenderer lineRenderer;
	Smoothness smoothnessScript;

	[SerializeField]
	int points = 8;

	List<Transform> nodes = new List<Transform>();

	float timeToStop;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = points + 1;
		smoothnessScript = GetComponent<Smoothness>();
		smoothnessScript.scripts = new List<HoldingDistance>();

		GameObject go = Instantiate(nodePrefab, player.position + Vector3.down, Quaternion.identity, transform);
		nodes.Add(go.transform);
		HoldingDistance script = go.GetComponent<HoldingDistance>();
		script.target = player;
		script.maxDistance = firstNodeDistance;
		smoothnessScript.scripts.Add(script);
		Attacking.closestNode = go.transform;

		for (int i = 0; i < points - 1; i++)
		{
			GenerateNode();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(addNode))
			AddNode();
		if (Input.GetKeyDown(removeNode))
			RemoveNode();

		if (timeToStop != 0f && timeToStop <= Time.time)
		{
			timeToStop = 0f;
			for (int i = 0; i < nodes.Count; i++)
			{
				//nodes[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}
	}

	void GenerateNode()
	{
		GameObject go = Instantiate(nodePrefab, nodes[nodes.Count - 1].position + Vector3.down, Quaternion.identity, transform);
		HoldingDistance script = go.GetComponent<HoldingDistance>();
		script.target = nodes[nodes.Count - 1];
		nodes.Add(go.transform);
		smoothnessScript.scripts.Add(script);
	}

	void DestroyNode()
	{
		GameObject go = nodes[nodes.Count - 1].gameObject;
		nodes.RemoveAt(nodes.Count - 1);
		smoothnessScript.scripts.RemoveAt(smoothnessScript.scripts.Count - 1);
		Destroy(go);
	}

	public void AddNode()
	{
		points++;
		lineRenderer.positionCount = points;
		GenerateNode();
	}

	public void RemoveNode()
	{
		points--;
		lineRenderer.positionCount = points;
		DestroyNode();
	}

	public void Attack(Vector3 force)
	{
		for (int i = 0; i < nodes.Count; i++)
		{
			nodes[i].GetComponent<Rigidbody2D>().AddForce(force * Mathf.Pow(pow, i));
		}
		timeToStop = Time.time + 0.35f;
	}
}
