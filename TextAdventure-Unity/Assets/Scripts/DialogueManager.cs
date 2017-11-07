using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{

	protected Text text;
	protected DialogueContainer dialogueContainer;
	protected int currentAIArrayPosition = 0;
	protected int currentPlayerArrayPosition = 0;
	protected string currentPlayerString;
	protected string currentAIString;

	void Awake ()
	{
		Initialise ();
	}

	protected void Initialise ()
	{
		dialogueContainer = GameObject.FindObjectOfType<DialogueContainer>();
		text = GetComponentInChildren<Text>();
	}

	protected virtual void AddMessageToConversation (string currentString)
	{
		text.text = currentString;
	}	

	protected virtual void FindNextConversationString ()
	{

	}
}
