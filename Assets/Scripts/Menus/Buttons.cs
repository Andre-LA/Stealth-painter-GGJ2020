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
        SceneManager.UnloadSceneAsync(7);
    }
}
