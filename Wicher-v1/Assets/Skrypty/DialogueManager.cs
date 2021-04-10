using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //public string ClassName;
    public GameObject Dialog;
    public GameObject Tell;
    [SerializeField]
    public Dialogue Dialogue;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Npc;
    public TextMeshProUGUI Option1;
    public TextMeshProUGUI Option2;
    public TextMeshProUGUI Option3;
    public bool been;
    public bool PlayerInRange;
    private string currentText = "";
    public float delay;
    public PlayerMovement PlayerMovement;
    public int Choose = 0;
    public int dodatek;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Imie;
    public NPC NPC;
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
            Tell.SetActive(true);
            Name.text = Dialogue.name;
            Option1.text = Dialogue.Option1;
            Option2.text = Dialogue.Option2;
            Option3.text = Dialogue.Option3;
            StartCoroutine(NPC0());
            PlayerMovement.WDialogu();
        }
        
    }
    public IEnumerator NPC0()
    {

        for (int i = 0; i < Dialogue.Npc.Length; i++)
        {
            currentText = Dialogue.Npc.Substring(0, i);
            this.Npc.text = currentText;
            yield return new WaitForSeconds(delay);


        }
    }
    public void OptionOne()
    {
        Choose += dodatek;
        if (Choose == 1)
        {
            Option1.text = Dialogue.Option11;
            Option2.text = Dialogue.Option21;
            StartCoroutine(NPC1());
        }
        else if(Choose == 2)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            StartCoroutine(NPC2());
        }
    }
    public IEnumerator NPC1()
    {

        for (int i = 0; i < Dialogue.Npc1.Length; i++)
        {
            currentText = Dialogue.Npc1.Substring(0, i);
            this.Npc.text = currentText;
            yield return new WaitForSeconds(delay);


        }
    }
    public void OptionTwo()
    {
        Choose += dodatek;
        if (Choose == 1)
        {
            Option1.text = Dialogue.Option11;
            Option2.text = Dialogue.Option21;
            StartCoroutine(NPC2());
        }
        else if (Choose == 2)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            StartCoroutine(NPC1());
        }
    }
    public IEnumerator NPC2()
    {

        for (int i = 0; i < Dialogue.Npc2.Length; i++)
        {
            currentText = Dialogue.Npc2.Substring(0, i);
            this.Npc.text = currentText;
            yield return new WaitForSeconds(delay);


        }
    }
    public void OptionEnd()
    {
        if (Choose == 2)
        {
            been = true;
            NPC.byl();
        }
        StartCoroutine(Koniec());
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
            this.Npc.text = currentText;
            yield return new WaitForSeconds(delay);


        }
        yield return new WaitForSeconds(0.5f);

        Dialog.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        
    }
    public void byl()
    {
        Dialog.SetActive(true);
        Tell.SetActive(true);
        StartCoroutine(NPC4());
        PlayerMovement.NiewDialogu();
    }
    public IEnumerator NPC4()
    {

        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        for (int i = 0; i < Dialogue.Npc4.Length; i++)
        {
            currentText = Dialogue.Npc4.Substring(0, i);
            this.Npc.text = currentText;
            yield return new WaitForSeconds(delay);


        }
        yield return new WaitForSeconds(0.5f);

        Dialog.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
}

