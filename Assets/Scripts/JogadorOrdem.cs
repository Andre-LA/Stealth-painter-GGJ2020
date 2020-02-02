using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorOrdem : MonoBehaviour
{
    public Renderer sprRender;
    public float deslocamento;
    
    void Update()
    {
        sprRender.sortingOrder = Mathf.FloorToInt((-transform.position.y)*100 + deslocamento*100);
    }
}
