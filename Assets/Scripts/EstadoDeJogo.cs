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
    public static bool gameIsOver;
    public static bool loreOnScreen;
    public static bool levelIsStarting;
    public static string interactive;
    private bool stopLoading;

    private void Start()
    {
        gameIsPaused = false;
        gameIsOver = false;
        stopLoading = false;
        levelIsStarting = true;
        loreOnScreen = true;
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
        if (gameIsOver && !stopLoading)
        {
            stopLoading = true;
            playerSteps.Stop();
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameIsOver = true;
        }
        if (levelIsStarting)
        {
            levelIsStarting = false;
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync(8, LoadSceneMode.Additive);
        }
    }
}
