using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioTxt : MonoBehaviour
{

	public Text mytext = null;
	private int counter = 1;
	public void changeText()
	{
		counter++;
		if (counter % 2 == 1)
		{
			mytext.text = " Audio: off";
		}
		else
		{
			mytext.text = "Audio: on";
		}
	}
}