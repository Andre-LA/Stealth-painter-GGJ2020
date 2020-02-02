using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParedeTranslucida : MonoBehaviour
{
    public Tilemap tilemapParede;
    public Color corTranslucida;
    public float vel;
    
    public Vector2 regiaoMin, regiaoMax;
    public bool dentro;
    
    Transform jogador;
    
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        Vector3 pos = jogador.position;
        
        dentro = (pos.x > regiaoMin.x && 
            pos.x < regiaoMax.x && 
            pos.y < regiaoMax.y && 
            pos.y > regiaoMin.y);
            
        tilemapParede.color = Color.Lerp(
            tilemapParede.color,
            dentro ? corTranslucida : Color.white,
            Time.deltaTime * vel
        );
    }
}
