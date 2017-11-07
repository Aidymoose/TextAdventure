using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDialogueManager : DialogueManager 
{
	void Start () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		base.Initialise ();
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayPosition];
		AddMessageToConversation (currentAIString);
	}

	protected override void AddMessageToConversation (string currentString)
	{
		base.AddMessageToConversation (currentString);
	}

	protected override void FindNextConversationString ()
	{
		currentAIArrayPosition +=1;
		currentAIString = dialogueContainer.AITextSequence[currentAIArrayPosition];
		AddMessageToConversation (currentAIString);
	}

	public void UpdateAIText ()
	{
		FindNextConversationString ();
	}
}
