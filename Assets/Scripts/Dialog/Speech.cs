using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Speech #", menuName = "ScriptableObjects/Speech")]
public class Speech : ScriptableObject
{
	public Character character;
	[TextArea]
	public string text;
	public AudioClip sound;
	public int numberOfChoices = 0;
	public bool onLeft = true;

	[Space]
	[Header("Global Varables Object")]
	public GlobalVariables variablesObject;

	[Space]
	[Header("Without choice")]
	public string variableToChange;
	public bool newValue;
	public Speech nextSpeech;
	public UnityEvent ToDo;

	[Space]
	[Header("Choice #1")]
	public string variableToChange1;
	public bool newValue1;
	public Speech nextSpeech1;
	public UnityEvent ToDo1;

	[Space]
	[Header("Choice #2")]
	public string variableToChange2;
	public bool newValue2;
	public Speech nextSpeech2;
	public UnityEvent ToDo2;

	[Space]
	[Header("Choice #3")]
	public string variableToChange3;
	public bool newValue3;
	public Speech nextSpeech3;
	public UnityEvent ToDo3;

	[Space]
	[Header("Choice #4")]
	public string variableToChange4;
	public bool newValue4;
	public Speech nextSpeech4;
	public UnityEvent ToDo4;
}
