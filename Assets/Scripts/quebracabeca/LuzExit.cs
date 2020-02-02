using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LuzExit : MonoBehaviour
{
    Light2D light2D;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        StartCoroutine(Atualizar());
    }
    
    IEnumerator Atualizar()
    {
        while (true)
        {
            if (EstadoDeJogo.podeProsseguirFase)
            {
                light2D.enabled = true;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
