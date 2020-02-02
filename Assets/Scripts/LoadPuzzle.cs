using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene painting;
    static bool jaInicializou = false;
    
    void Start()
    {
        if (!jaInicializou)
        {
            CheckInteraction.onMonalisaStart += CallPuzzle;
            CheckInteraction.onMonalisaExit += HidePuzzle;
            CheckInteraction.onMonalisaReEnter += ShowPuzzle;
            jaInicializou = true;
        }
    }

    private void CallPuzzle()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        painting = SceneManager.GetSceneByBuildIndex(1);
        EstadoDeJogo.quadroAberto = true;
    }

    private void HidePuzzle()
    {
        EstadoDeJogo.quadroAberto = false;
        Debug.Log("Hiding Scene");
        GameObject[] sceneObjects = painting.GetRootGameObjects();
        foreach(GameObject obj in sceneObjects)
        {
            obj.SetActive(false);
        }
    }

    private void ShowPuzzle()
    {
        EstadoDeJogo.quadroAberto = true;
        Debug.Log("Showing Scene");
        GameObject[] sceneObjects = painting.GetRootGameObjects();
        foreach (GameObject obj in sceneObjects)
        {
            obj.SetActive(true);
        }
    }
}
