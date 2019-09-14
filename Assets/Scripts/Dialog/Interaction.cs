using UnityEngine;

public class Interaction : MonoBehaviour
{
	[SerializeField]
	KeyCode interactionKey = KeyCode.E;

	bool isInsideInteractive = false;
	NiggaScript script;

	Attacking attacking;
	PlayerMovement movement;

	public static Interaction singleton;
	private void Awake()
	{
		singleton = this;
	}

	private void Start()
	{
		attacking = GetComponent<Attacking>();
		movement = GetComponent<PlayerMovement>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		script = collision.GetComponent<NiggaScript>();
		if (script != null)
		{
			isInsideInteractive = true;
			script.Select();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<NiggaScript>() != null)
		{
			isInsideInteractive = false;
			script.Deselect();
			script = null;
		}
	}

	private void Update()
	{
		if (isInsideInteractive && Input.GetKeyDown(interactionKey))
		{
			DisableInput();
			script.Interact();
		}
	}

	public void DisableInput()
	{
		attacking.enabled = false;
		movement.enabled = false;
	}

	public void EnableInput()
	{
		attacking.enabled = true;
		movement.enabled = true;
	}
}
