using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGlow : MonoBehaviour 
{
	GameObject[] _allKeys;
	GameObject _space;

	void Awake () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		_allKeys = GameObject.FindGameObjectsWithTag("Key");
		_space = GameObject.FindGameObjectWithTag("Space");
	}

	public void FindButtonToGlow (char currentGlowKey)
	{
		if (currentGlowKey == ' ')
		{
			_space.GetComponent<KeyFunctionality>().SetToGlow();
			PlayerInputController playerInputController = GameObject.FindObjectOfType<PlayerInputController>();
			playerInputController.SetCurrentIndexToNull();
		}
		else
		{
			foreach (GameObject key in _allKeys)
			{
				string buttonID = key.GetComponentInChildren<Text>().text;
				char letter = buttonID.ToCharArray()[0];
				if(letter == currentGlowKey)
				{
				print("Button ID is " + buttonID);
				key.GetComponent<KeyFunctionality>().SetToGlow ();
				}
			}
		}
	}

}
