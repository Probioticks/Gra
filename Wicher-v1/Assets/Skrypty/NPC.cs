using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPC : MonoBehaviour
{
  
    public  DialogueManager DialogueManager;
   
    public bool PlayerInRange;
    

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
       
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInRange == true)
        {
            
            DialogueManager.StartDialogue();
            

           
        }
       

       

    }
    
        
    }
