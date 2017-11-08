using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueManager : DialogueManager 
{
	string currentAIstring;
	public GameObject nPCConversationContainer;
	public List<GameObject> nPCMessageList = new List <GameObject>();
	
	void Start () 
	{
		Initialise ();
	}

	protected override void Initialise ()
	{
		base.Initialise ();
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayIndex];
		GameObject thisNPCMessageContainer = Instantiate (nPCMessageContainer, nPCConversationContainer.transform);
		print (currentAIString);
		AddMessageToConversation (currentAIString, thisNPCMessageContainer, nPCMessageList);
	}

	protected override void AddMessageToConversation (string currentString, GameObject thisMessageContainer,  List<GameObject> messageList)
	{
		base.AddMessageToConversation (currentString, thisMessageContainer, nPCMessageList);
	}

	protected override void FindNextConversationString ()
	{
		currentAIArrayIndex +=1;
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayIndex];
		GameObject thisMessageContainer = Instantiate (nPCMessageContainer, nPCConversationContainer.transform);
		AddMessageToConversation (currentAIString, thisMessageContainer, nPCMessageList);
	}

	public void UpdateAIText ()
	{
		FindNextConversationString ();
	}



}
