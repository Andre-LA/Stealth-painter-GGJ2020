using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeJogo : MonoBehaviour
{
    public enum Quadros {
        Monalisa = 0,
    }

    public static int quadroAbertoID = 0;
    public static bool quadroAberto;
    public static bool podeProsseguirFase;
}
