using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheckCameraNonVc : MonoBehaviour {

	public GameObject platformToCreate;
	private bool isCreated;

	void Update()
	{
		if (PlayerCameraManager.cameraTransitionPlayer == true)
		{
			isCreated = false;
		}
		else if (isCreated == false)
		{
			Instantiate(platformToCreate, transform.position, Quaternion.identity);
			isCreated = true;
		}
	}
}

