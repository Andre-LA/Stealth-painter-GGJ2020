using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePuzzle : MonoBehaviour
{
    public GameObject[] quadros;
    MatrizQuadro quadroAtual;

    void OnEnable()
    {
        EstadoDeJogo.quadroAberto = true;
        for (int i = 0; i < quadros.Length; i++)
        {
            bool ativo = i == EstadoDeJogo.faseAtual;
            
            if (ativo)
                quadroAtual = quadros[i].GetComponent<MatrizQuadro>();

            quadros[i].SetActive(ativo);
        }
    }
    
    void OnDisable()
    {
        EstadoDeJogo.quadroAberto = false;
    }
    
    void Update()
    {
        if (quadroAtual)
        {
            if (quadroAtual.resolvido) 
            {
                EstadoDeJogo.podeProsseguirFase = true;
            }
        }
    }
}
