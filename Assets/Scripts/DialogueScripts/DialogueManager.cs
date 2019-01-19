using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    private bool keyPressed = true;
	private bool sentenceFinished = false;

	public Text nameText;
	public Text dialogueText;
	public AudioSource typingSound;
	public Animator animator;
	public GameObject arrow;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
    public void Update()
    {

		if (Input.GetButtonDown("Fire2") && sentenceFinished == true)
        {
            DisplayNextSentence();
			sentenceFinished = false;
			arrow.SetActive(false);
        }
    }
	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
       
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));

	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			typingSound.Play();
			dialogueText.text += letter;
			yield return null;
		}
		Debug.Log("done");
		sentenceFinished = true;
		arrow.SetActive(true);
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
