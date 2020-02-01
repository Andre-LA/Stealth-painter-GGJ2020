using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePuzzle : MonoBehaviour
{
    public GameObject[] quadros;

    void OnEnable()
    {
        for (int i = 0; i < quadros.Length; i++)
        {
            Debug.Log(i.ToString() + " , " + EstadoDeJogo.quadroAbertoID.ToString());
            quadros[i].SetActive(i == EstadoDeJogo.quadroAbertoID);
        }
    }
}
