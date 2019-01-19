using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDialogue : MonoBehaviour {

    private bool switchPos = true;
    private bool switchJab = true;
    private int counter = 0;

    public GameObject jabPink;
    public Animator intro;
	public Animator jabAnim;
    public GameObject dialogue;
    public AudioSource jab;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("j") && switchPos)
        {
            transform.position = new Vector2(1000, 200);
            switchPos = false;
            counter++;
        }
        else if (Input.GetKeyDown("j") && !switchPos)
        {
            transform.position = new Vector2(1000, 413);
            switchPos = true;
            counter++;
        }
        if (counter >=4)
        {
            if (switchJab == true)
            {
                switchJab = false;
                jab.Play();
                jabPink.SetActive(true);
				jabAnim.SetTrigger("JabTrigger");
            }
  
            intro.SetTrigger("Fade");
            Destroy(dialogue);
            Destroy(gameObject,1);
         
        }
    }
}
