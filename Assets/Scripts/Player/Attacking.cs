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

	void FixedUpdate()
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

		distance = Vector2.ClampMagnitude(distance, distanceToClosestNode * 2f);

		if (distance.magnitude > 0.08f)
		{
			root.Attack(distance * force * Time.fixedDeltaTime);
		}
	}

	public void GetAttacked()
	{
		root.RemoveNode();
	}
}
