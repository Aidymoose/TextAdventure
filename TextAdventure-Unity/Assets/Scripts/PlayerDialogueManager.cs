using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueManager : DialogueManager 
{
	GameObject _sendButton;
	PlayerInputController _playerInputController;
	AiDialogueManager _aIDialogueManager;
	string _resetTyping = " ";

	void Start () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		base.Initialise ();
		_playerInputController = GameObject.FindObjectOfType<PlayerInputController>();
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayPosition];
		_aIDialogueManager = GameObject.FindObjectOfType<AiDialogueManager>();
		_sendButton = GameObject.FindGameObjectWithTag ("Send");
		_playerInputController.SetCurrentMessage (currentPlayerString);
	}

	public void AllPlayerMessageCharactersTyped ()
	{
		_sendButton.GetComponent<KeyFunctionality>().SetToGlow ();
	}

	public void PlayerConfirmsSendMessage ()
	{
		AddMessageToConversation (currentPlayerString);
	}

	protected override void AddMessageToConversation (string currentString)
	{
		base.AddMessageToConversation (currentString);
		_playerInputController.ResetTypeToScreen (_resetTyping);
		_sendButton.GetComponent<KeyFunctionality>().EndGlow ();
		FindNextConversationString ();
		_aIDialogueManager.UpdateAIText ();
	}		

	protected override void FindNextConversationString ()
	{
		currentPlayerArrayPosition +=1;
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayPosition];
		_playerInputController.SetCurrentMessage(currentPlayerString);
	}
}
