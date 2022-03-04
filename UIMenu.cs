using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public GameObject storyScreen;

    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void cre2Menu()
    {
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void story2First()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
