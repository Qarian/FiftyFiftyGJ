using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vulnerable : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnDeath = default;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Hairs script = collision.transform.parent.GetComponent<Hairs>();
		if (script == null)
			return;

		script.AddNode();
		OnDeath.Invoke();
		Destroy(transform.parent.gameObject);
	}
}
