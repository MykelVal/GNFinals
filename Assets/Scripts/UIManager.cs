using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuGroup, aboutGroup, exitGroup, pauseGroup;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //MainMenu Scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AboutButton()
    {
        mainMenuGroup.SetActive(false);
        aboutGroup.SetActive(true);
    }

    public void BackButtonFromAbout()
    {
        mainMenuGroup.SetActive(true);
        aboutGroup.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    //YouWin Scene
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //YouLose Scene
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    //Pause Button
    public void Pause()
    {
        pauseGroup.SetActive(true);
    }
    public void Resume()
    {
        pauseGroup.SetActive(false);
    }
}
