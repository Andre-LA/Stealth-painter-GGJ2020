using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstadoDeJogo : MonoBehaviour
{
    public enum Quadros {
        Monalisa = 0,
    }

    public AudioSource playerSteps;

    public static bool quadroAberto;
    public static bool podeProsseguirFase;
    public static int faseAtual;
    public static bool gameIsPaused;

    private void Start()
    {
        gameIsPaused = false;
    }
    public void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameIsPaused)
        {
            playerSteps.Stop();
            gameIsPaused = true;
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
        }
    }
}
