using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyFunctionality : MonoBehaviour 
{

	public char key;
	Color _newcolour = Color.red;
	Color _defaultColour = Color.white;

	public char GetKey ()
	{
		return key;
	}

	public void SetToGlow ()
	{
		ColorBlock colorBlock = GetComponent<Button>().colors;
		colorBlock.normalColor = _newcolour;
		GetComponent<Button>().colors = colorBlock;
	}

	public void EndGlow ()
	{
		ColorBlock colorBlock = this.GetComponent<Button>().colors;
		colorBlock.normalColor = _defaultColour;
		this.GetComponent<Button>().colors = colorBlock;
	}
}
