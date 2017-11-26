using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour 
{
	GameObject[] _allKeys;
	GameObject _space;

	void Awake () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		_allKeys = GameObject.FindGameObjectsWithTag("Key");
		_space = GameObject.FindGameObjectWithTag("Space");
	}

	public void FindButtonToGlow (char currentGlowKey)
	{
		if (currentGlowKey == ' ')
		{
			print ("space detected");
			_space.GetComponent<KeyFunctionality>().SetToGlow();
			PlayerInputController playerInputController = GameObject.FindObjectOfType<PlayerInputController>();
			playerInputController.SetCurrentIndexToNull();
		}
		else
		{
			foreach (GameObject key in _allKeys)
			{
				string buttonID = key.GetComponentInChildren<Text> ().text;
				char letter = buttonID.ToCharArray () [0];
				if (letter == currentGlowKey)
				{
					print ("Button ID is " + buttonID);
					key.GetComponent<KeyFunctionality> ().SetToGlow ();
					return;
				}
			}
		}
	}

	public void CheckCharacterCase (char currentCharacter)
	{
		if (char.IsUpper(currentCharacter))
		{
			SetCaseToUpper(currentCharacter);
			print ("Upper case detected: " + currentCharacter);
		}
		else if (char.IsLower(currentCharacter))
		{
			SetCaseToLower(currentCharacter);
			print ("Lower case detected: " + currentCharacter);
		}
		else
		{
			FindButtonToGlow(currentCharacter);
		}
	}

	public void SetCaseToUpper (char currentCharacter)
	{
		foreach (GameObject key in _allKeys)
		{
			Text keyText = key.GetComponentInChildren<Text> ();
			string buttonID = keyText.text;
			keyText.text = buttonID.ToUpper();
		}
		FindButtonToGlow(currentCharacter);
	}

	public void SetCaseToLower (char currentCharacter)
	{
		foreach (GameObject key in _allKeys)
		{
			Text keyText = key.GetComponentInChildren<Text> ();
			string buttonID = keyText.text;
			keyText.text = buttonID.ToLower();
		}
		FindButtonToGlow(currentCharacter);
	}

	public string SetOnClickStringCase (string buttonOnClickString, char currentCharacterInMessage)
	{
		if (char.IsLower(currentCharacterInMessage))
		{
			string verifiedString = buttonOnClickString.ToLower();
			return verifiedString;
		}
		else if (char.IsUpper(currentCharacterInMessage))
		{
			string verifiedString = buttonOnClickString.ToUpper();
			return verifiedString;
		}
		else
		{
			return buttonOnClickString;
		}
	}
}
