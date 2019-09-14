using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField]
	Hairs root = default;

	[Space]
	[SerializeField]
	float distanceToClosestNode = 0.4f;
	[SerializeField]
	float force = 3;

	public static Transform closestNode = default;

	[Space]
	[SerializeField]
	KeyCode keyAttack = KeyCode.Mouse0;

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

		if (distance.magnitude > 0.1f)
		{
			/*Debug.Log("Node: " + ((Vector2)closestNode.position - (Vector2)transform.position) +
			"\nInput: " + (inputPosition - (Vector2)transform.position) +
			"\nDistance: " + distance.magnitude);*/
			root.Attack(distance * force * Time.deltaTime);
		}
	}
}
