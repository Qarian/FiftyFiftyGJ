using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowUICharacter : MonoBehaviour
{
	[SerializeField]
	Image UIPortrait;
	[SerializeField]
	TextMeshProUGUI UICharacterName;

	[Space]
	public Character character;

	public void HideCharacter()
	{
		gameObject.SetActive(false);
	}

	public void ShowCharacter()
	{
		UIPortrait.sprite = character.portrait;
		UICharacterName.text = character.characterName;
		gameObject.SetActive(true);
	}
}
