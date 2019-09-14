using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField]
	Transform closestNode = default;
	[SerializeField]
	float distanceToClosestNode = 0.4f;

	[SerializeField]
	float force = 3;

	[Space]
	[SerializeField]
	KeyCode keyAttack = KeyCode.Mouse0;

	Hairs root;

	private void Start()
	{
		root = GetComponent<Hairs>();
	}

	void Update()
    {
		if (Input.GetKey(keyAttack))
			Attack();
    }

	void Attack()
	{
		Vector2 mouse = Input.mousePosition;
		Vector2 pos = Camera.main.ScreenToWorldPoint(mouse);

		Vector2 distance = pos - (Vector2)transform.position;

		distance = distance.normalized * distanceToClosestNode;

		Vector2 inputPosition = (Vector2)transform.position + distance;

		distance = inputPosition - (Vector2)closestNode.position;

		if (distance.magnitude > 0.15f)
		{
			Debug.Log("Node: " + ((Vector2)closestNode.position - (Vector2)transform.position) +
			"\nInput: " + (inputPosition - (Vector2)transform.position) +
			"\nDistance: " + distance.magnitude);
			root.Attack(distance * force * Time.deltaTime);
		}
	}
}
