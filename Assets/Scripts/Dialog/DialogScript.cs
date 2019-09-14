using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class DialogScript : MonoBehaviour
{
	[SerializeField]
	ShowUICharacter leftPosition;
	[SerializeField]
	ShowUICharacter rightPosition;
	[SerializeField]
	TextMeshProUGUI text;

	[Space]
	[SerializeField]
	KeyCode continueKey;

	AudioSource audioSource;

	Speech currentSpeech;

	void Update()
	{
		for (int i = 0; i < 4; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				Debug.Log(i);
			}
		}


		if (currentSpeech == null)
			return;

		if (currentSpeech.numberOfChoices == 0)
		{
			if (Input.GetKeyDown(continueKey))
				NextSpeech(0);
		}
		else
		{
			
		}
	}

	public void ShowSpeech(Speech speech)
	{
		if (speech.onLeft)
		{
			leftPosition.ShowCharacter();
			rightPosition.HideCharacter();
		}
		else
		{
			rightPosition.ShowCharacter();
			leftPosition.HideCharacter();
		}

		text.text = speech.text;

		audioSource.clip = speech.sound;
		audioSource.Play();


		gameObject.SetActive(true);
	}

	void NextSpeech(int number)
	{

	}

	public void HideCnavas()
	{
		leftPosition.HideCharacter();
		rightPosition.HideCharacter();
		gameObject.SetActive(false);
	}
}
