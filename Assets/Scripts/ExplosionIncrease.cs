using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionIncrease : MonoBehaviour {

    float fallDelay = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(0.7F, 0.7F, 0);
        StartCoroutine(Fall());
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        Destroy(gameObject);
        yield return 0;
    }
}
