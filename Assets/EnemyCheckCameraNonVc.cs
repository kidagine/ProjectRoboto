using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckCameraNonVc : MonoBehaviour
{
	public GameObject enemyToCreate;
	private bool isCreated;

	void Update()
	{
		if (PlayerCameraManager.cameraTransitionPlayer == true)
		{
			isCreated = false;
		}
		else if (isCreated == false)
		{
			Instantiate(enemyToCreate, transform.position, Quaternion.identity);
			isCreated = true;
		}
	}
}
