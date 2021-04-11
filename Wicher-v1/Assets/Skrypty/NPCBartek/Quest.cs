using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
    [SerializeField]
    public Questing Questing;
    public bool questactive;
    public TextMeshProUGUI title;
    public TextMeshProUGUI destription;
    public TextMeshProUGUI questgoal;
    public GameObject Quest1;
    public bool completed;
    public NPCBartek NPC;
   
    
    public void StartQuest1()
    {
        questactive = true;
        Quest1.SetActive(true);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && questactive == true)
        {
            Questing.questgoal += 1;
        }
        if(questactive == true && completed == false)
        {
           
            title.text = Questing.title;
            destription.text = Questing.destription;
            questgoal.text = "(" + Questing.questgoal.ToString() + "/" + Questing.finalgoal.ToString() + ")";

        }
        if(questactive == true && Questing.questgoal == Questing.finalgoal)
        {
            completed = true;
            Quest1.SetActive(false);
            questactive = false;
            NPC.Quest1();
        }
        
    }
    public void UpdateGoal()
    {
        Questing.questgoal += 1;
    }
   
}
