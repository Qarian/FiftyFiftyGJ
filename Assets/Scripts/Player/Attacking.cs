using UnityEngine;

public class Attacking : MonoBehaviour
{
	[SerializeField]
	float cooldown = 3f;

	[Space]
	[SerializeField]
	KeyCode keyAttack = KeyCode.Mouse0;

	float lastAttack = 0f;


    void Update()
    {
		if (Input.GetKeyDown(keyAttack))
			Attack();
    }

	void Attack()
	{

	}
}
