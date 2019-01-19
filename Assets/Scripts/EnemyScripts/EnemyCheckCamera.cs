using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckCamera : MonoBehaviour {
	public GameObject enemyToCreate;
	public GameObject enemyChecker;
	private Enemy enemy;
	private bool isCreated;
	void Start() {
		enemy = GetComponent<Enemy>();
		Destroy(enemy);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyChecker")
			if (isCreated == false)
			{
				EnemyCreate();
			}
	}

	private void EnemyCreate()
	{
		Instantiate(enemyToCreate, transform.position, Quaternion.identity);
		Debug.Log(isCreated);
		isCreated = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyChecker")
			if (isCreated == true) {
				isCreated = false;
			}
	}



	// Update is called once per frame
	void Update()
	{
		if (PlayerCameraManager.cameraTransitionPlayer == true)
		{
			enemyChecker.SetActive(false);
		}
		else
			enemyChecker.SetActive(true);

		if (PlayerCameraManager.cameraTransitionPlayer == true)
			isCreated = false;
	}
}
