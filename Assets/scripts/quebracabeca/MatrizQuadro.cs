﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrizQuadro : MonoBehaviour
{
    public bool resolvido;
    public int quadroID; // talvez desnecessário
    public int[,] matriz;
    
    int[][,] matrizes = new int [2][,];
    
    void Awake()
    {
        matrizes[0] = new int[3,3]{{2, 0, 1}, 
                                   {3, 8, 5},
                                   {6, 7, 4}};
                                   
        matrizes[1] = new int[3,3]{{1, 0, 5}, 
                                   {8, 3, 2},
                                   {6, 7, 4}};
    
        matriz = matrizes[EstadoDeJogo.faseAtual];
    }
    
    void Update()
    {
        resolvido = VerificaResolvido();
    }
    
    bool VerificaResolvido()
    {
        int anterior = -1;
        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 3; x++) {
                if (y == 0 && x == 0 && matriz[y, x] != 0)
                    return false;
                
                if (y != 0 && x != 0 && matriz[y, x] - anterior != 1)
                    return false;
                
                anterior = matriz[y, x];
            }
        }
        return true;
    }
    
    bool EValido(int x, int y)
    {
        return (x >= 0 && x < 3) && (y >= 0 && y < 3);
    }
    
    void FazerAlternacao(int x1, int y1, int x2, int y2)
    {
        Debug.Log(string.Concat("antes:\n", MatrizToString()));
        
        int _m = matriz[y2, x2];
        matriz[y2, x2] = matriz[y1, x1];
        matriz[y1, x1] = _m;
        
        Debug.Log(string.Concat("depois:\n", MatrizToString()));
    }
    
    public void Alternar(int x, int y)
    {
        if (resolvido)
            return;
            
        // direita  é x+1, y-0
        // cima     é x-0, y-1
        // esquerda é x-1, y-0
        // baixo    é x-0, y+1
        
        Debug.Log("Alternando x:" + x.ToString() + ", y:" + y.ToString());
        
        // direita
        int xd = x+1; int yd = y;
        if (EValido(xd, yd)) {
            if (matriz[yd, xd] == 0) {
                FazerAlternacao(x, y, xd, yd);
                return;
            }
        }
        
        // cima
        int xc = x; int yc = y-1;
        if (EValido(xc, yc)) {
            if (matriz[yc, xc] == 0) {
                FazerAlternacao(x, y, xc, yc);
                return;
            }
        }
        
        // esquerda
        int xe = x-1; int ye = y;
        if (EValido(xe, ye)) {
            if (matriz[ye, xe] == 0) {
                FazerAlternacao(x, y, xe, ye);
                return;
            }
        }
        
        // baixo
        int xb = x; int yb = y+1;
        if (EValido(xb, yb)) {
            if (matriz[yb, xb] == 0) {
                FazerAlternacao(x, y, xb, yb);
                return;
            }
        }
    }
    
    string MatrizToString()
    {
        string insp = "[";
        for (int i = 0; i < 3; i++) {
            insp = insp + string.Concat(i==0?"":" ", "[", matriz[i, 0], ",", matriz[i, 1], ",", matriz[i, 2], "]\n");
        }
        insp = insp + "]";
        return insp;
    }
    
    [ContextMenu("Testar Alterna 0x1")] public void TestarAlterna_01 () { Alternar(0, 1); }
    [ContextMenu("Testar Alterna 1x0")] public void TestarAlterna_10 () { Alternar(1, 0); }
    [ContextMenu("Testar Alterna 1x1")] public void TestarAlterna_11 () { Alternar(1, 1); }
    
    [ContextMenu("Pode prosseguir")] public void PodeProsseguir () { EstadoDeJogo.podeProsseguirFase = true; }
    
}
