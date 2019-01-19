using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullscreenTxt : MonoBehaviour
{

	public Text mytext = null;
	private int counter = 1;
	public void changeText()
	{
		counter++;
		if (counter % 2 == 1)
		{
			mytext.text = " Fullscreen: off";
		}
		else
		{
			mytext.text = "Fullscreen: on";
		}
	}
}