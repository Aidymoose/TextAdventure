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
	KeyboardController _keyboardController;
	PlayerDialogueManager _playerDialogueManager;
	Text _text;

	void Awake () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		_playerDialogueManager = GameObject.FindObjectOfType<PlayerDialogueManager>();
		_keyboardController = GameObject.FindObjectOfType<KeyboardController>();
		_text = this.GetComponentInChildren<Text>();
	}

	public void PlayerHasPressedKey (string keyValue)
	{
		char currentPlayerMessageCharacter = _currentPlayerMessageCharacters[_playerMessageCharacterIndex];
		string keyValueCase = _keyboardController.SetOnClickStringCase(keyValue,currentPlayerMessageCharacter);
		char keyPressed = keyValueCase.ToCharArray()[0];
		print ("key pressed is " + keyPressed);
		if (keyPressed == currentPlayerMessageCharacter)
		{
			UpdateCurrentPlayerMessageText ();
			GameObject button = EventSystem.current.currentSelectedGameObject;
			button.GetComponent<KeyFunctionality>().EndGlow();
			FindNextPlayerMessageCharacter ();
		}
	}

	private void UpdateCurrentPlayerMessageText ()
	{
		_text.text = _playerCurrentMessage.Substring(0,_playerMessageCharacterIndex + 1);
	}

	private void FindNextPlayerMessageCharacter ()
	{
		_playerMessageCharacterIndex += 1;
		print ("_playerMessageCharacterIndex  is " + _playerMessageCharacterIndex + " and _currentPlayerMessageCharactersLength is " + _currentPlayerMessageCharactersLength);
		if (_playerMessageCharacterIndex == _currentPlayerMessageCharactersLength)
			{
				_playerDialogueManager.AllPlayerMessageCharactersTyped ();
			}
		else
		{
			char next = _currentPlayerMessageCharacters[_playerMessageCharacterIndex];
			print ("Next character is " + next);
			_keyboardController.CheckCharacterCase (next);
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
		char first = _currentPlayerMessageCharacters[0];
		_keyboardController.CheckCharacterCase (first);
	}

	public void SetCurrentIndexToNull ()
	{
		_currentPlayerMessageCharacters[_playerMessageCharacterIndex] = ' ';
	}
}
