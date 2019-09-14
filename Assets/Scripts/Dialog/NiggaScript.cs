using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NiggaScript : MonoBehaviour
{
	public Speech firstSpeech;
	public List<UnityEvent> events;

	[Space]
	[SerializeField]
	Color selectedColor = default;

	SpriteRenderer sprite;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	public void Select()
	{
		sprite.color = selectedColor;
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
