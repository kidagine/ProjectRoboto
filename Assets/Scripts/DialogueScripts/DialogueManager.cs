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
	public StartDialogue startDialogue;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
    public void Update()
    {

		if ( Input.GetKey(KeyCode.J) && sentenceFinished == true)
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
		sentenceFinished = true;
		arrow.SetActive(true);
	}

	void EndDialogue()
	{
		PlayerMovementBasic.isDialogueActive = false;
		animator.SetBool("IsOpen", false);
	}

}
