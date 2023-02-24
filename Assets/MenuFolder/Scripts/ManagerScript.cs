using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject settingsMenu;

    public void CloseGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
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
}
