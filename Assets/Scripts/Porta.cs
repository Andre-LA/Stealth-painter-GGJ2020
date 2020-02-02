using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public int proxCenaIdx;
    public bool naoTemQuadro;
    
    void Start()
    {
        EstadoDeJogo.podeProsseguirFase = false; //naoTemQuadro;
    }
        
    public void ProsseguirFase()
    {
        SceneManager.LoadScene(proxCenaIdx);
        Debug.Log("Proxima fase!");
    }
}
