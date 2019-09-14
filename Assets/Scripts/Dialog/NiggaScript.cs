using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NiggaScript : MonoBehaviour
{
	public Speech firstSpeech;
	public List<UnityEvent> events;

	SpriteRenderer sprite;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	public void Select()
	{
		sprite.color = new Color(220f / 255f, 100f / 255f, 85f / 255f);
		Debug.Log("qrwetwryiyguhi;");
	}

	public void Deselect()
	{
		sprite.color = Color.white;
	}

	public void Interact()
	{
		DialogScript.singleton.StartSpeech(firstSpeech, events);
	}
}
