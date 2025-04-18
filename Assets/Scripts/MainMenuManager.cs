using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenu, ControlsMenu;
    void Start()
    {
        ShowMainMenu();
    }
    
    public void ShowMainMenu()
    {
        MainMenu?.SetActive(true);
        ControlsMenu?.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShowControls()
    {
        MainMenu?.SetActive(false);
        ControlsMenu?.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotToScene0()
    {
        SceneManager.LoadScene(0);
    }
}
