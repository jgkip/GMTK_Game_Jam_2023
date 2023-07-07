using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string newGame = "Game";

    public void NewGame()
    {
        SceneManager.LoadScene(newGame);
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
