using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;


public class MainMenu : MonoBehaviour
{
    public GameObject LevelLoader;
    public Slider slider;
    public Text progressText;
    public float delay = 100000000f;
    public void LoadScene(string SceneName)
    {
        StartCoroutine(LoadAsynchronously(SceneName));
        
    }
    IEnumerator LoadAsynchronously (string SceneName)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        LevelLoader.SetActive(true);
        
        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            
            slider.value = progress;
            progressText.text = progress * 100f + "%";
           
            yield return null;
        }
        
    }
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
