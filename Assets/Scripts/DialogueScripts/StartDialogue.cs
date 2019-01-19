using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour {
    public Dialogue dialogue;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || (other.gameObject.tag == "PlayerHead")) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
         
        }
    }
}
