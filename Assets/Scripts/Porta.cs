using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public int proxCenaIdx;
    
    public void ProsseguirFase()
    {
        SceneManager.LoadScene(proxCenaIdx);
        Debug.Log("Proxima fase!");
    }
}
