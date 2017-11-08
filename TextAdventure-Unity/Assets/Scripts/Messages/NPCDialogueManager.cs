using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueManager : DialogueManager 
{
	string currentAIstring;
	public GameObject nPCConversationContainer;
	public GameObject thisNPCMessageContainer;
	public List<GameObject> nPCMessageList = new List <GameObject>();
	public Sprite smallMessageSprite;
	public Sprite mediumMessageSprite;
	public Sprite largeMessageSprite;
	PlayerDialogueManager playerDialogueManager;
	
	void Start () 
	{
		Initialise ();
	}

	protected override void Initialise ()
	{
		base.Initialise ();
		playerDialogueManager = GetComponent<PlayerDialogueManager>();
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayIndex];
		thisNPCMessageContainer = Instantiate (nPCMessageContainer, nPCConversationContainer.transform);
		print (currentAIString);
		AddMessageToConversation (currentAIString, thisNPCMessageContainer, nPCMessageList, nPCMessageContainer);
	}

	protected override void AddMessageToConversation (string currentString, GameObject newMessageContainer,  List<GameObject> messageList, GameObject previousMessageContainer)
	{
		base.AddMessageToConversation (currentString, newMessageContainer, nPCMessageList, previousMessageContainer);
		//SetMessageSprite(currentString,newMessageContainer,smallMessageSprite, mediumMessageSprite, largeMessageSprite, messageList);
	}

	protected override void FindNextConversationString (GameObject previousMessage)
	{
		currentAIArrayIndex +=1;
		print ("Current AI Array Index: " + currentAIArrayIndex);
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayIndex];
		StartCoroutine(WaitForNextMessage(previousMessage));
	}

	public void UpdateAIText (GameObject previousMessage)
	{
		FindNextConversationString (previousMessage);
	}

	IEnumerator WaitForNextMessage (GameObject previousMessage)
	{
		yield return new WaitForSeconds (4);
		thisNPCMessageContainer = Instantiate (nPCMessageContainer, nPCConversationContainer.transform);
		print ("Instantiated with height " + thisNPCMessageContainer.GetComponentInChildren<RectTransform>().rect.height);
		AddMessageToConversation (currentAIString, thisNPCMessageContainer, nPCMessageList, previousMessage);
		playerDialogueManager.IncrementYPositionOfCurrentMessages(thisNPCMessageContainer, playerDialogueManager.playerMessageList);
		playerDialogueManager.BeginNextStringLoop(previousMessage);
	}

}
