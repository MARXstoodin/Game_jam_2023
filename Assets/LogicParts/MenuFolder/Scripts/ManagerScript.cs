using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject startStory;
    public GameObject fireSound;

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        if (settingsMenu.active)
        {
            settingsMenu.SetActive(false);
        }
        else if (!settingsMenu.active)
        {
            settingsMenu.SetActive(true);
        }
    }

    public void showStart()
    {
        startStory.SetActive(true);
        fireSound.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
