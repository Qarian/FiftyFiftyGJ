using UnityEngine;

[CreateAssetMenu(fileName = "Character #", menuName ="ScriptableObjects/Character")]
public class Character : ScriptableObject
{
	public Sprite portrait;
	public string characterName;
}
