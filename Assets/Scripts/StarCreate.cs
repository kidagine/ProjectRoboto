using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCreate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var position =  new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(gameObject, position, Quaternion.identity);

    }
}
