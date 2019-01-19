using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyChecker : MonoBehaviour {

	public GameObject playerHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = playerHead.transform.position;
	}
}
