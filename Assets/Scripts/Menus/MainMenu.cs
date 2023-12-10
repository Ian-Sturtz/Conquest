using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayLocal()
    {
        SceneManager.LoadScene("Board");
    }

    public void PlayLan()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void QuitGame()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }
}
