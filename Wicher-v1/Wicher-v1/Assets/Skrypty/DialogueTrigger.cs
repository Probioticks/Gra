using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool playerinrange;
    public int dialog;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            playerinrange = true;

            DialogueTriggers();
        }

    }
    public void DialogueTriggers()
    {

        if (playerinrange == true)
        {


            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            dialog = 1;
        }
        else
        {
            dialog = 0;
        }
        


    }
}