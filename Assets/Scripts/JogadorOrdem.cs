using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorOrdem : MonoBehaviour
{
    public Renderer sprRender;
    public float deslocamento;
    public bool naoAtualizar;
    
    void Start()
    {
        sprRender.sortingOrder = Mathf.FloorToInt((-transform.position.y)*100 + deslocamento*100);    
    }
    
    void Update()
    {
        if (!naoAtualizar)
            sprRender.sortingOrder = Mathf.FloorToInt((-transform.position.y)*100 + deslocamento*100);
    }
}
