﻿using UnityEngine;

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
	[Header("Variable to Check")]
	public string variableToCheck;
	public int minValue;

	[Space]
	[Header("Without choice")]
	public string variableToChange;
	public int newValue;
	public Speech nextSpeech;
	public int ToDo = -1;

	[Space]
	[Header("Choice #1")]
	public string variableToChange1;
	public int newValue1;
	public Speech nextSpeech1;
	public int ToDo1 = -1;

	[Space]
	[Header("Choice #2")]
	public string variableToChange2;
	public int newValue2;
	public Speech nextSpeech2;
	public int ToDo2 = -1;

	[Space]
	[Header("Choice #3")]
	public string variableToChange3;
	public int newValue3;
	public Speech nextSpeech3;
	public int ToDo3 = -1;

	[Space]
	[Header("Choice #4")]
	public string variableToChange4;
	public int newValue4;
	public Speech nextSpeech4;
	public int ToDo4 = -1;
}
