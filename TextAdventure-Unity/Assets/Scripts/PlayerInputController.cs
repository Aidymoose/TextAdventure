using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour 
{

	char[] _currentPlayerMessageCharacters;
	int _playerMessageCharacterIndex = 0;
	int _currentPlayerMessageCharactersLength;
	string _playerCurrentMessage;
	ButtonGlow _buttonGlow;
	PlayerDialogueManager _playerDialogueManager;
	Text _text;

	void Start () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		_playerDialogueManager = GameObject.FindObjectOfType<PlayerDialogueManager>();
		_buttonGlow = GameObject.FindObjectOfType<ButtonGlow>();
		_text = this.GetComponentInChildren<Text>();
	}

	public void PlayerHasPressedKey (string keyvalue)
	{
		char key = keyvalue.ToCharArray()[0];
		GameObject button = EventSystem.current.currentSelectedGameObject;
		if (key == _currentPlayerMessageCharacters[_playerMessageCharacterIndex])
		{
			UpdateCurrentPlayerMessageText ();
			FindNextPlayerMessageCharacter (button);
		}
	}

	private void UpdateCurrentPlayerMessageText ()
	{
		_text.text = _playerCurrentMessage.Substring(0,_playerMessageCharacterIndex + 1);
	}

	private void FindNextPlayerMessageCharacter (GameObject button)
	{
		_playerMessageCharacterIndex += 1;
		if (_playerMessageCharacterIndex == _currentPlayerMessageCharactersLength)
			{
				_playerDialogueManager.AllPlayerMessageCharactersTyped ();
				button.GetComponent<KeyFunctionality>().EndGlow();
			}
		else
		{
			char next = _currentPlayerMessageCharacters[_playerMessageCharacterIndex];
			button.GetComponent<KeyFunctionality>().EndGlow();
			_buttonGlow.FindButtonToGlow(next);
		}
	}

	public void ResetTypeToScreen (string blank)
	{
		_text.text = blank;
		_playerMessageCharacterIndex = 0;
	}

	public void SetCurrentMessage (string newString)
	{
		_playerCurrentMessage = newString;
		_currentPlayerMessageCharacters = _playerCurrentMessage.ToCharArray ();
		_currentPlayerMessageCharactersLength = _currentPlayerMessageCharacters.Length;
		char firstLetter = _currentPlayerMessageCharacters[0];
		_buttonGlow.FindButtonToGlow (firstLetter);

	}
}
