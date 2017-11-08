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
	protected int currentAIArrayIndex = 0;
	protected int currentPlayerArrayIndex = 0;
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

	protected virtual void AddMessageToConversation (string currentString, GameObject currentMessageContainer, List<GameObject> messageList)
	{
		text = currentMessageContainer.GetComponentInChildren<Text>();
		text.text = currentString;
		messageList.Add(currentMessageContainer);
	}	

	protected virtual void FindNextConversationString ()
	{

	}
}
