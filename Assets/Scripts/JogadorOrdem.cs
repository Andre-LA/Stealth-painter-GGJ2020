using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorOrdem : MonoBehaviour
{
    public Renderer sprRender;
    public float deslocamento, multiplicador;
    
    void Update()
    {
        sprRender.sortingOrder = Mathf.FloorToInt((-transform.position.y)*multiplicador + deslocamento*multiplicador);
    }
}
