using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogPoQuest1 : MonoBehaviour
{
    [SerializeField]
    public Dialogue Dialogue;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI NpcText;
    public TextMeshProUGUI Option1;
    public TextMeshProUGUI Option2;
    public TextMeshProUGUI Option3;
    public bool been;
    public bool PlayerInRange;
    private string currentText;
    public float delay;
    public PlayerMovement PlayerMovement;
    public int Choose;
    public int dodatek;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Dialog;
    public GameObject Tell;
    public NPCBartek NPC;
    public Quest Quest1;
    public void Awake()
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
        else
        {

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

    }
    public void OptionOne()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        StartCoroutine(NPC2());

    }
    public void OptionTwo()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        StartCoroutine(NPC3());
    }
    public void OptionEnd()
    {
        StartCoroutine(NPC4());
        been = true;
    }
    public IEnumerator NPC4()
    {

        for (int i = 0; i < Dialogue.Npc4.Length; i++)
        {
            currentText = Dialogue.Npc4.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);




        }

        yield return new WaitForSeconds(1f);

        Dialog.SetActive(false);

    }
    public IEnumerator NPC2()
    {

        for (int i = 0; i < Dialogue.Npc2.Length; i++)
        {
            currentText = Dialogue.Npc2.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);




        }
        yield return new WaitForSeconds(2f);

        OptionEnd();
    }
    public IEnumerator NPC3()
    {

        for (int i = 0; i < Dialogue.Npc3.Length; i++)
        {
            currentText = Dialogue.Npc3.Substring(0, i);
            this.NpcText.text = currentText;
            yield return new WaitForSeconds(delay);




        }
        yield return new WaitForSeconds(2f);
        OptionEnd();
    }
}
