using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;


public class LoadingMenu : MonoBehaviour
{

    public GameObject piewszy;
    public GameObject drugi;
    public GameObject trzeci;
    public int czas;
    public string SceneName;
    
    
    void Start()
    {

        piewszy.SetActive(false);
        drugi.SetActive(false);
        trzeci.SetActive(false);


        piewszy.SetActive(true);
        new WaitForSeconds(czas);
        Debug.Log("1");
        piewszy.SetActive(false);

        drugi.SetActive(true);

         new WaitForSeconds(czas);
        Debug.Log("1");
        drugi.SetActive(false);

        trzeci.SetActive(true);

         new WaitForSeconds(czas);
        Debug.Log("1");
        trzeci.SetActive(false);

        StartCoroutine(MenuLoad());

    }
    public IEnumerator MenuLoad()
    {
        piewszy.SetActive(true);
        yield return new WaitForSeconds(czas);
        Debug.Log("1");
        piewszy.SetActive(false);

        drugi.SetActive(true);

        yield return new WaitForSeconds(czas);
        Debug.Log("1");
        drugi.SetActive(false);

        trzeci.SetActive(true);

        yield return new WaitForSeconds(czas);
        Debug.Log("1");
        
        yield return new WaitForSeconds(czas);
        
        SceneManager.LoadScene(SceneName);
    }
    
   
}
