using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
 
    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && EstadoDeJogo.gameIsPaused)
        {
            Continue();
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        EstadoDeJogo.gameIsPaused = false;
        if (EstadoDeJogo.loreOnScreen)
        {
            EstadoDeJogo.loreOnScreen = false;
            SceneManager.UnloadSceneAsync(8);
        }
        else
        {
            SceneManager.UnloadSceneAsync(7);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(EstadoDeJogo.faseAtual);
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(7);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void NewGame()
    {

    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
