using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 3;

	Rigidbody2D rb;

	Vector2 inputDir;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private void FixedUpdate()
	{
		Vector2 pos = new Vector2(transform.position.x, transform.position.y);
		rb.MovePosition(pos + inputDir * speed * Time.fixedDeltaTime);
	}
}
