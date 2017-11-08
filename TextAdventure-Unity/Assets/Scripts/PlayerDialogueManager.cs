using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueManager : DialogueManager 
{
	GameObject _sendButton;
	PlayerInputController _playerInputController;
	NPCDialogueManager _nPCDialogueManager;
	string _resetTyping = " ";
	public GameObject playerConversationContainer;

	void Start () 
	{
		Initialise ();
	}

	protected override void Initialise ()
	{
		base.Initialise ();
		_playerInputController = GameObject.FindObjectOfType<PlayerInputController>();
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayPosition];
		_nPCDialogueManager = GameObject.FindObjectOfType<NPCDialogueManager>();
		_sendButton = GameObject.FindGameObjectWithTag ("Send");
		_playerInputController.SetCurrentMessage (currentPlayerString);
	}

	public void AllPlayerMessageCharactersTyped ()
	{
		_sendButton.GetComponent<KeyFunctionality>().SetToGlow ();
	}

	public void PlayerConfirmsSendMessage ()
	{
		GameObject thisPlayerMessageContainer = Instantiate (PlayerMessageContainer, playerConversationContainer.transform);
		AddMessageToConversation (currentPlayerString, thisPlayerMessageContainer);
	}

	protected override void AddMessageToConversation (string currentString, GameObject thisMessageContainer)
	{
		base.AddMessageToConversation (currentString, thisMessageContainer);
		_playerInputController.ResetTypeToScreen (_resetTyping);
		_sendButton.GetComponent<KeyFunctionality>().EndGlow ();
		FindNextConversationString ();
		_nPCDialogueManager.UpdateAIText ();
	}		

	protected override void FindNextConversationString ()
	{
		currentPlayerArrayPosition +=1;
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayPosition];
		_playerInputController.SetCurrentMessage(currentPlayerString);
	}
}
