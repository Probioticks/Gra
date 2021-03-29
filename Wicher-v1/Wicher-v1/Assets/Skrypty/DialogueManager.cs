using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public float delay = 0.1f;
    public Animator animator;
    


    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		

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
            Debug.Log("Koniec");
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
			dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
	}
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DisplayNextSentence();
        }

    }
        void EndDialogue()
        {

        }
    
}
