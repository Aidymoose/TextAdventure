using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{
	public GameObject nPCMessageContainer;
	public GameObject PlayerMessageContainer;
	protected Text text;
	protected DialogueContainer dialogueContainer;
	protected int currentAIArrayPosition = 0;
	protected int currentPlayerArrayPosition = 0;
	protected string currentPlayerString;
	protected string currentAIString;
	protected Transform nPCConversationTransform;

	void Start ()
	{
		Initialise ();
	}

	protected virtual void Initialise ()
	{
		dialogueContainer = GameObject.FindObjectOfType<DialogueContainer>();
	}

	protected virtual void AddMessageToConversation (string currentString, GameObject currentMessageContainer)
	{
		text = currentMessageContainer.GetComponentInChildren<Text>();
		text.text = currentString;
	}	

	protected virtual void FindNextConversationString ()
	{

	}
}
