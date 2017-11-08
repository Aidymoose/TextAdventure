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

	protected virtual void AddMessageToConversation (string currentString, GameObject newMessageContainer, List<GameObject> messageList, GameObject previousMessageContainer)
	{
		IncrementYPositionOfCurrentMessages(previousMessageContainer, messageList);
		text = newMessageContainer.GetComponentInChildren<Text>();
		text.text = currentString;
		messageList.Add(newMessageContainer);
		print("Message List: " + messageList);
	}	

	protected virtual void FindNextConversationString (GameObject previousMessage)
	{

	}

	public void IncrementYPositionOfCurrentMessages (GameObject newestMessageContainer, List<GameObject> messageList)
	{
		float messageHeight = newestMessageContainer.GetComponentInChildren<RectTransform>().rect.height;
		print ("Message Height: " + messageHeight);
		MessageVisualBehaviorController messageVisualBehaviorController = GetComponent<MessageVisualBehaviorController>();
		foreach (GameObject message in messageList)
		{
			messageVisualBehaviorController.IncreaseYTransform(message,messageHeight);
			print ("Object moved: " + message);
		}
	}

	protected virtual void SetMessageSprite (string newMessage, GameObject newMessageContainer, Sprite smallDefaultSprite, Sprite mediumDefaultSprite, Sprite largeDefaultSprite, List<GameObject> messageList)
	{
		int smallMessageLimit = 40;
		int mediumMessageLimit = 90;
		int largeMessageLimit = 250;
		Image defaultImage = newMessageContainer.GetComponentInChildren<Image>();
		print ("Current sprite length: " + newMessage.Length);

		if (newMessage.Length <= smallMessageLimit)
		{
			defaultImage.sprite = smallDefaultSprite;
			print ("Small Using " + smallDefaultSprite);
		}
		else if (newMessage.Length > smallMessageLimit && newMessage.Length <= mediumMessageLimit)
		{
			defaultImage.sprite = mediumDefaultSprite;
			print ("Medium Using " + mediumDefaultSprite);
		}
		else if (newMessage.Length> mediumMessageLimit && newMessage.Length <= largeMessageLimit)
		{
			defaultImage.sprite = largeDefaultSprite;
			print ("Large Using " + largeDefaultSprite);
		}
	}
}
