using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicTxt : MonoBehaviour
{

	public Text mytext = null;
	private int counter = 1;
	public void changeText()
	{
		counter++;
		if (counter % 2 == 1)
		{
			mytext.text = " Music: off";
		}
		else
		{
			mytext.text = "Music: on";
		}
	}
}
