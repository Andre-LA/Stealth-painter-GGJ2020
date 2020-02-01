using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesenhaQuebraCabeca : MonoBehaviour
{
    public MatrizQuadro quadro;
    public Transform pedacos;
        
    void AchaNum(ref int x, ref int y, int n)
    {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                int v = quadro.matriz[i, j];
                if (v == n) {
                    x = j;
                    y = i;
                    return;
                }
            }            
        }    
    }
    
    void Update()
    {
        for (int i = 0; i < pedacos.childCount; i++)
        {
            Transform tr_pedaco = pedacos.GetChild(i);
            tr_pedaco.gameObject.name = i.ToString();
            RectTransform pedaco_i = tr_pedaco.GetComponent<RectTransform>();
            
            int x = 0;
            int y = 0;
            
            AchaNum(ref x, ref y, i);
            
            pedaco_i.anchorMin = new Vector2(1f/3f *  x   , 1f - (1f/3f * (y+1)));
            pedaco_i.anchorMax = new Vector2(1f/3f * (x+1), 1f - (1f/3f *  y   ));    
        }
    }
    
    public void Deslizar(GameObject v)
    {
        Debug.Log("Dezlizar:" + v.name);
        int i = int.Parse(v.name);
        
        for (int _y = 0; _y < 3; _y++)
        {
            for (int _x = 0; _x < 3; _x++)
            {
                if (quadro.matriz[_y, _x] == i) {
                    quadro.Alternar(_x, _y);
                    return;
                }
            }        
        }        
    }
}
