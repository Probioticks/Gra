using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public bool playerinrange;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerinrange = true;
            Debug.Log("Tak");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText()); 
    }
    IEnumerator ShowText()
    {
        if (playerinrange == true)
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
