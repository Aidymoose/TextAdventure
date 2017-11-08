using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageVisualBehaviorController : MonoBehaviour 
{
	public void IncreaseYTransform(GameObject message, float yDistance)
	{
		message.transform.Translate(0,yDistance,0);
		print (message + " has moved " + yDistance);
	}

}
