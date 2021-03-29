using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerEconomy : MonoBehaviour
{
    public Text wynik;
    public int currentobs;
    
    
   public void UpdateEconomy(int Money)
    {
        currentobs += Money;
       wynik.text = currentobs.ToString();

    }

  

    
   
}