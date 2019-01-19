using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    }
}
