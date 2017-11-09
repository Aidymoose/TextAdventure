using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueManager : DialogueManager 
{
	public GameObject conversationContainer;
	public List<GameObject> playerMessageList;
	GameObject _sendButton;
	PlayerInputController _playerInputController;
	NPCDialogueManager _nPCDialogueManager;
	string _resetTyping = " ";


	void Start () 
	{
		Initialise ();
	}

	protected override void Initialise ()
	{
		base.Initialise ();
		_playerInputController = GameObject.FindObjectOfType<PlayerInputController>();
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayIndex];
		_nPCDialogueManager = GetComponent<NPCDialogueManager>();
		_sendButton = GameObject.FindGameObjectWithTag ("Send");
		_sendButton.GetComponent<Button>().interactable = false;
		playerMessageList = new List<GameObject>();
		_playerInputController.SetCurrentMessage (currentPlayerString);
	}

	public void AllPlayerMessageCharactersTyped ()
	{
		_sendButton.GetComponent<Button>().interactable = true;
		_sendButton.GetComponent<KeyFunctionality>().SetToGlow ();
		print (_sendButton + " is glowing");
	}

	public void PlayerConfirmsSendMessage ()
	{
		GameObject thisPlayerMessageContainer = Instantiate (PlayerMessageContainer, conversationContainer.transform);
		_nPCDialogueManager.IncrementYPositionOfCurrentMessages(thisPlayerMessageContainer, _nPCDialogueManager.nPCMessageList);
		GameObject previousMessageContainer = _nPCDialogueManager.thisNPCMessageContainer;
		AddMessageToConversation (currentPlayerString, thisPlayerMessageContainer ,playerMessageList,previousMessageContainer);
		print ("NPC message is " + previousMessageContainer);
		_sendButton.GetComponent<Button>().interactable = false;
	}

	protected override void AddMessageToConversation (string currentString, GameObject newMessageContainer,  List<GameObject> messageList, GameObject previousMessageContainer)
	{
		base.AddMessageToConversation (currentString, newMessageContainer, playerMessageList, previousMessageContainer);
		_playerInputController.ResetTypeToScreen (_resetTyping);
		_sendButton.GetComponent<KeyFunctionality>().EndGlow ();
		_nPCDialogueManager.UpdateAIText (newMessageContainer);
	}		

	protected override void FindNextConversationString (GameObject previousMessage)
	{
		currentPlayerArrayIndex +=1;
		print (currentPlayerArrayIndex);
		currentPlayerString = dialogueContainer.PlayerTextSequence[currentPlayerArrayIndex];
		_playerInputController.SetCurrentMessage(currentPlayerString);
	}

	public void BeginNextStringLoop(GameObject previousMessage)
	{
		FindNextConversationString(previousMessage);
	}
}
