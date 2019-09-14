using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Global Variable", menuName = "ScriptableObjects/Global Variable")]
public class GlobalVariables : ScriptableObject
{
	public List<Pair> values;
}

[System.Serializable]
public struct Pair
{
	public string name;
	public bool active;
}
