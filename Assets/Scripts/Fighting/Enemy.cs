using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	float rotationSpeed = 1f;
	[SerializeField]
	float speed = 1f;

	Rigidbody2D rb;
	Transform player;
	float lastCollision = 0f;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Vector3 vecToplayer = player.position - transform.position;
		if (vecToplayer.magnitude > 10f)
			return;

		Vector3 forward = transform.up;
		Vector3 diff = player.position - transform.position;
		diff.Normalize();

		//Vector3 newForward = Vector3.Lerp(forward, diff, rotationSpeed * Time.deltaTime);
		Vector3 newForward = Vector3.MoveTowards(forward, diff, rotationSpeed * Time.deltaTime);
		newForward.Normalize();

		float rot_z = Mathf.Atan2(newForward.y, newForward.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	private void FixedUpdate()
	{
		if (player == null)
			return;

		Vector3 vecToplayer = player.position - transform.position;

		if (vecToplayer.magnitude < 10f)
		{
			rb.MovePosition(transform.position + vecToplayer.normalized * speed * Time.deltaTime);
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		Attacking script = collision.transform.GetComponent<Attacking>();
		if (script != null)
		{
			script.GetAttacked();
		}
	}
}
