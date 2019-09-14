using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowUICharacter : MonoBehaviour
{
	[SerializeField]
	Image UIPortrait = default;
	[SerializeField]
	TextMeshProUGUI UICharacterName = default;

	public void HideCharacter()
	{
		gameObject.SetActive(false);
	}

	public void ShowCharacter(Character character)
	{
		UIPortrait.sprite = character.portrait;
		UICharacterName.text = character.characterName;
		gameObject.SetActive(true);
	}
}
