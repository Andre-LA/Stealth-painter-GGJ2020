using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizadorEstadoDeJogo : MonoBehaviour
{
    public bool _DEBUG_quadroAberto;
    public bool _DEBUG_podeProsseguirFase;
    public int _DEBUG_faseAtual;
    
    void Update()
    {
        _DEBUG_quadroAberto = EstadoDeJogo.quadroAberto;
        _DEBUG_podeProsseguirFase = EstadoDeJogo.podeProsseguirFase;
        _DEBUG_faseAtual = EstadoDeJogo.faseAtual;
    }
}
