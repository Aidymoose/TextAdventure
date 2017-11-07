using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGlow : MonoBehaviour 
{
	private GameObject[] _allKeys;

	void Awake () 
	{
		Initialise ();
	}

	void Initialise ()
	{
		_allKeys = GameObject.FindGameObjectsWithTag("Key");
	}

	public void FindButtonToGlow (char currentGlowKey)
	{
		print ("finding key to glow");
		foreach (GameObject key in _allKeys)
		{
			char letter = key.GetComponent<KeyFunctionality>().GetKey ();
			if(letter == currentGlowKey)
			{
				key.GetComponent<KeyFunctionality>().SetToGlow ();
			}
		}
	}

}
