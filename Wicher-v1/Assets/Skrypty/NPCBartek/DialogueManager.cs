using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //public string ClassName;

    [SerializeField]
    public Dialogue Dialogue;
    public TextMeshProUGUI Name ;
    public TextMeshProUGUI NpcText ;
    public TextMeshProUGUI Option1 ;
    public TextMeshProUGUI Option2 ;
    public TextMeshProUGUI Option3 ;
    public bool been ;
    public bool PlayerInRange ;
    private string currentText ;
    public float delay ;
    public PlayerMovement PlayerMovement;
    public int Choose ;
    public int dodatek ;
    public GameObject Button1 ;
    public GameObject Button2 ;
    public GameObject Button3 ;
    public GameObject Dialog ;
    public GameObject Tell ;
    public NPCBartek NPC ;
    public Quest Quest1;
    public void Awake()
    {
      
        

    }
    
    public void Update()
    {
      
    }
    public void StartDialogue()
    {
        if (been == false)
        {
            PlayerInRange = true;
            Dialog.SetActive(true);
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Tell.SetActive(true);
            Name.text = Dialogue.name;
            Option1.text = Dialogue.Option1;
            Option2.text = Dialogue.Option2;
            Option3.text = Dialogue.Option3;
            StartCoroutine(NPC0());
            PlayerMovement.WDialogu();
        }
        if(been == true )
        {
            PlayerInRange = true;
            Dialog.SetActive(true);
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Tell.SetActive(true);
            OptionEnd();
        }
        
    }
    public IEnumerator NPC0()
    {

        for (int i = 0; i < Dialogue.Npc.Length; i++)
        {
            currentText = Dialogue.Npc.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);
            
                
            

        }
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
    public void OptionOne()
    {
        Choose += dodatek;
        if (Choose == 1)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Option1.text = Dialogue.Option11;
            Option2.text = Dialogue.Option21;
            StartCoroutine(NPC1());
        }
        else if (Choose == 2)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Option1.text = Dialogue.Option12;
            Option2.text = Dialogue.Option22;
            StartCoroutine(NPC2());

        }
        else if (Choose == 3)
        {
            StartCoroutine(Koniec());
            Quest1.StartQuest1();
            been = true;
            PlayerMovement.NiewDialogu();
        }
        
       
    }
    public IEnumerator NPC1()
    {

        for (int i = 0; i < Dialogue.Npc1.Length; i++)
        {
            currentText = Dialogue.Npc1.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);
            
               
            

        }
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
    
    public IEnumerator NPC2()
    {

        for (int i = 0; i < Dialogue.Npc2.Length; i++)
        {
            currentText = Dialogue.Npc2.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);
            
                
          
        }
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
    public void OptionEnd()
    {
        if ( been == false)
        {
           
            StartCoroutine(Koniec1());


        }
        else
        {
            StartCoroutine(Koniec2());
        }
        PlayerMovement.NiewDialogu();

    }
    public IEnumerator Koniec()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        for (int i = 0; i < Dialogue.Npc3.Length; i++)
        {
            currentText = Dialogue.Npc3.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);


        }
        yield return new WaitForSeconds(0.5f);

        Dialog.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);

    }
    public IEnumerator Koniec1()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        for (int i = 0; i < Dialogue.Npc5.Length; i++)
        {
            currentText = Dialogue.Npc5.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);


        }
        yield return new WaitForSeconds(0.5f);

        Dialog.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        
    }
    public IEnumerator Koniec2()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        for (int i = 0; i < Dialogue.Npc4.Length; i++)
        {
            currentText = Dialogue.Npc4.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);


        }
        yield return new WaitForSeconds(0.5f);

        Dialog.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);

    }
   

}

