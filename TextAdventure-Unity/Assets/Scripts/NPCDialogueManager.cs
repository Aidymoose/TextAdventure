using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueManager : DialogueManager 
{
	string currentAIstring;
	public GameObject nPCConversationContainer;
	
	void Start () 
	{
		Initialise ();
	}

	protected override void Initialise ()
	{
		base.Initialise ();
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayPosition];
		GameObject thisNPCMessageContainer = Instantiate (nPCMessageContainer, nPCConversationContainer.transform);
		print (currentAIString);
		AddMessageToConversation (currentAIString, thisNPCMessageContainer);
	}

	protected override void AddMessageToConversation (string currentString, GameObject thisMessageContainer)
	{
		base.AddMessageToConversation (currentString, thisMessageContainer);
	}

	protected override void FindNextConversationString ()
	{
		currentAIArrayPosition +=1;
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayPosition];
		GameObject thisMessageContainer = Instantiate (nPCMessageContainer);
		AddMessageToConversation (currentAIString, thisMessageContainer);
	}

	public void UpdateAIText ()
	{
		FindNextConversationString ();
	}


}
