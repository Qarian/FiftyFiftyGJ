using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField]
	float cooldown = 3f;

	public Vector3 force;

	[Space]
	[SerializeField]
	KeyCode keyAttack = KeyCode.Mouse0;

	float lastAttack = 0f;

	Hairs root;

	private void Start()
	{
		root = GetComponent<Hairs>();
	}

	void Update()
    {
		if (Input.GetKeyDown(keyAttack) && Time.time > lastAttack + cooldown)
		{
			lastAttack = Time.time;
			root.Attack();
		}
    }
}
