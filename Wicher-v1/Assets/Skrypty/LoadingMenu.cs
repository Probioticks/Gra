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
    public bool isFullScreen;
  

    void Start()
    {

        piewszy.SetActive(false);
        drugi.SetActive(false);
        trzeci.SetActive(false);


       

        StartCoroutine(MenuLoad());
        
    }
    void Update()
    {
      
        StartCoroutine(Updates());
       
    }
    public IEnumerator MenuLoad()
    {
        piewszy.SetActive(true);

        yield return new WaitForSeconds(czas);
        piewszy.SetActive(false);
        drugi.SetActive(true);
        yield return new WaitForSeconds(czas);
        
        

        videoplayer.SetActive(true);
        trzeci.SetActive(true);
        yield return new WaitForSeconds(1f);
        drugi.SetActive(false);
        
        yield return new WaitForSeconds(10f);
        


        SceneManager.LoadScene(SceneName);
        yield return new WaitForSeconds(1f);
        koniec.SetActive(false);
        


    }
    public IEnumerator Updates()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {

            SceneManager.LoadScene(SceneName);
            yield return new WaitForSeconds(1f);
            koniec.SetActive(false);

        }
    }
    







}
