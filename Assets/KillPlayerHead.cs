using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerHead : MonoBehaviour {
	public GameObject playerHead;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(playerHead);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
