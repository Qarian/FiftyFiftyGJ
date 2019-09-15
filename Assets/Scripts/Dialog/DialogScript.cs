using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class DialogScript : MonoBehaviour
{
	[SerializeField]
	ShowUICharacter leftPosition = default;
	[SerializeField]
	ShowUICharacter rightPosition = default;
	[SerializeField]
	TextMeshProUGUI text = default;

	[Space]
	[SerializeField]
	KeyCode continueKey = KeyCode.Space;

	AudioSource audioSource;

	Speech currentSpeech;
	List<UnityEvent> events;

	public static DialogScript singleton;
	private void Awake()
	{
		singleton = this;
		audioSource = GetComponent<AudioSource>();
		gameObject.SetActive(false);
	}

	void Update()
	{
		if (currentSpeech == null)
			return;

		if (currentSpeech.numberOfChoices == 0)
		{
			if (Input.GetKeyDown(continueKey))
			{
				int variableValue = -50;
				if (currentSpeech.variableToCheck != "")
				{
					for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
					{
						if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToCheck)
						{
							variableValue = currentSpeech.variablesObject.values[i].number;
							break;
						}
					}

					if (variableValue >= currentSpeech.minValue)
						NextSpeech(1);
					else
						NextSpeech(0);
				}
				else
					NextSpeech(0);
			}
		}
		else
		{
			for (int i = 0; i < currentSpeech.numberOfChoices; i++)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1 + i))
				{
					Debug.Log(i + 1);
				}
			}
		}
	}

	public void StartSpeech(Speech speech, List<UnityEvent> events)
	{
		this.events = events;
		ShowSpeech(speech);
	}

	void ShowSpeech(Speech speech)
	{
		currentSpeech = speech;
		if (speech.onLeft)
		{
			leftPosition.ShowCharacter(speech.character);
			rightPosition.HideCharacter();
		}
		else
		{
			rightPosition.ShowCharacter(speech.character);
			leftPosition.HideCharacter();
		}

		text.text = speech.text;

		audioSource.clip = speech.sound;
		audioSource.Play();

		gameObject.SetActive(true);
	}

	void NextSpeech(int number)
	{
		if (number == 0)
		{
			if (currentSpeech.variableToChange != "")
			{
				for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
				{
					if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToChange)
						currentSpeech.variablesObject.values[i].number = currentSpeech.newValue;
				}
			}
			if (currentSpeech.ToDo >= 0)
			{
				events[currentSpeech.ToDo].Invoke();
			}
			if (currentSpeech.nextSpeech != null)
				ShowSpeech(currentSpeech.nextSpeech);
			else
				HideCanvas();
		}

		if (number == 1)
		{
			if (currentSpeech.variableToChange != "")
			{
				for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
				{
					if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToChange1)
						currentSpeech.variablesObject.values[i].number = currentSpeech.newValue1;
				}
			}
			if (currentSpeech.ToDo1 >= 0)
			{
				events[currentSpeech.ToDo1].Invoke();
			}
			if (currentSpeech.nextSpeech1 != null)
				ShowSpeech(currentSpeech.nextSpeech1);
			else
				HideCanvas();
		}

		if (number == 2)
		{
			if (currentSpeech.variableToChange != "")
			{
				for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
				{
					if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToChange2)
						currentSpeech.variablesObject.values[i].number = currentSpeech.newValue2;
				}
			}
			if (currentSpeech.ToDo2 >= 0)
			{
				events[currentSpeech.ToDo2].Invoke();
			}
			if (currentSpeech.nextSpeech2 != null)
				ShowSpeech(currentSpeech.nextSpeech2);
			else
				HideCanvas();
		}

		if (number == 3)
		{
			if (currentSpeech.variableToChange != "")
			{
				for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
				{
					if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToChange3)
						currentSpeech.variablesObject.values[i].number = currentSpeech.newValue3;
				}
			}
			if (currentSpeech.ToDo3 >= 0)
			{
				events[currentSpeech.ToDo3].Invoke();
			}
			if (currentSpeech.nextSpeech3 != null)
				ShowSpeech(currentSpeech.nextSpeech3);
			else
				HideCanvas();
		}

		if (number == 4)
		{
			if (currentSpeech.variableToChange != "")
			{
				for (int i = 0; i < currentSpeech.variablesObject.values.Count; i++)
				{
					if (currentSpeech.variablesObject.values[i].name == currentSpeech.variableToChange4)
						currentSpeech.variablesObject.values[i].number = currentSpeech.newValue4;
				}
			}
			if (currentSpeech.ToDo4 >= 0)
			{
				events[currentSpeech.ToDo4].Invoke();
			}
			if (currentSpeech.nextSpeech4 != null)
				ShowSpeech(currentSpeech.nextSpeech4);
			else
				HideCanvas();
		}
	}

	public void HideCanvas()
	{
		leftPosition.HideCharacter();
		rightPosition.HideCharacter();
		gameObject.SetActive(false);
		Interaction.singleton.EnableInput();
	}
}
