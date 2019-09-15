using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Dangerous : MonoBehaviour
{
	AudioSource sound;

	float lastCollision = 0f;

	private void Start()
	{
		sound = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (lastCollision + 0.5f < Time.time)
		{
			collision.transform.parent.GetComponent<Hairs>().RemoveNode();

			lastCollision = Time.time;
			sound.Play();
		}
	}
}
