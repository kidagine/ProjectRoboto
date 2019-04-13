using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour {

	static public bool VC = false;
	static public bool VcVertical = false;
	static public bool VcUnlock = false;
	static public bool transition = false;
	static public bool transitionLeft = false;
	static public bool transitionUp = false;
	static public bool transitionDown = false;
	static public bool transistionHorizontal = false;
	static public bool transistionVertical = false;
	static public bool cameraTransitionPlayer = false;
	static public bool cameraTransitionPlayerSlowdown = false;
	public static bool cameraHasTransitioned = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.tag == "Player" || gameObject.tag == "PlayerHead")
		{
			if (other.gameObject.tag == "Transition")
				transition = true;
			if (other.gameObject.tag == "TransitionLeft")
				transitionLeft = true;
			if (other.gameObject.tag == "TransitionUp")
				transitionUp = true;
			if (other.gameObject.tag == "TransitionDown")
				transitionDown = true;
			if (other.gameObject.tag == "VC")
			{
				VcUnlock = false;
				VC = true;
			}
			if (other.gameObject.tag == "VcVertical")
				VcVertical = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (gameObject.tag == "Player" || gameObject.tag == "PlayerHead")
		{
			if (other.gameObject.tag == "VC" || other.gameObject.tag == "VcVertical" || other.gameObject.tag == "TransitionUp"  || other.gameObject.tag == "TransitionDown" || other.gameObject.tag == "TransitionLeft" || other.gameObject.tag == "Transition") 
				Transition();

		}
	}

	void Update()
	{
		if (!PauseMenu.GameIsPaused)
		{
			if (transitionDown || transitionUp || VcVertical)
			{

				cameraTransitionPlayer = true;
				cameraTransitionPlayerSlowdown = true;
				cameraHasTransitioned = false;
				transistionVertical = true;
				Time.timeScale = 0.7f;
			}
			else if (transition || transitionLeft || VC)
			{

				cameraTransitionPlayer = true;
				cameraTransitionPlayerSlowdown = true;
				cameraHasTransitioned = false;
				transistionHorizontal = true;
				Time.timeScale = 0.7f;
			}
			else
			{
				cameraHasTransitioned = true;
				Time.timeScale = 1;
			}
		}
	}

    private void Transition()
    {
		cameraTransitionPlayer = false;
		cameraTransitionPlayerSlowdown = false;
		transistionHorizontal = false;
		transistionVertical = false;
		transition = false;
		transitionLeft = false;
		transitionDown = false;
		transitionUp = false;
		VcVertical = false;
        VC = false;
 
    }
}
