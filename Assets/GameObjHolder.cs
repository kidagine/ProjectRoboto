using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjHolder : MonoBehaviour {

	private Vector3 startingPos;

	void Start()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		startingPos = transform.position;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyChecker")
		{
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			Debug.Log("true");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "EnemyChecker")
		{
			transform.position = startingPos;
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			Debug.Log("false");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
