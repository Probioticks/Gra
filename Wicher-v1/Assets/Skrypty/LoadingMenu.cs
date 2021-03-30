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
    public GameObject videoplayer;
    public GameObject koniec;
    public int czas;
    public string SceneName;
  

    void Start()
    {

        piewszy.SetActive(false);
        drugi.SetActive(false);
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
        videoplayer.SetActive(true);

        yield return new WaitForSeconds(12f);
        


        
        SceneManager.LoadScene(SceneName);
        koniec.SetActive(false);

    }
    
   
}
