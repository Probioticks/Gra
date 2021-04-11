using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPCBartek : MonoBehaviour
{
  
    public  DialogueManager Dialog1;
    public DialogPoQuest1 DialogPoQuest1;
   
    public bool PlayerInRange;
    public float quest;

    public  void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player")) 
        {
           
            
            PlayerInRange = true;
        }
        else
        {
            PlayerInRange = false;
            
        }
    }
   
    
    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInRange == true && quest == 0)
        {
            
            Dialog1.StartDialogue();
            

           
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInRange == true && quest == 1)
        {


            DialogPoQuest1.StartDialogue();


        }




    }
    
     public void Quest1() {
        quest += 1;
    }
    }
