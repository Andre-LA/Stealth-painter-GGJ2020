using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene painting;
    void Start()
    {
        CheckInteraction.onMonalisaStart += CallPuzzle;
        CheckInteraction.onMonalisaExit += HidePuzzle;
        CheckInteraction.onMonalisaReEnter += ShowPuzzle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CallPuzzle()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        painting = SceneManager.GetSceneByBuildIndex(1);
    }

    private void HidePuzzle()
    {
        Debug.Log("Hiding Scene");
        GameObject[] sceneObjects = painting.GetRootGameObjects();
        foreach(GameObject obj in sceneObjects)
        {
            obj.SetActive(false);
        }
    }

    private void ShowPuzzle()
    {
        Debug.Log("Showing Scene");
        GameObject[] sceneObjects = painting.GetRootGameObjects();
        foreach (GameObject obj in sceneObjects)
        {
            obj.SetActive(true);
        }
    }
}
