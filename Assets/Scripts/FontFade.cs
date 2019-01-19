using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontFade : MonoBehaviour {
    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
        {
            animator.SetBool("Fade", true);

        }
    }
}
