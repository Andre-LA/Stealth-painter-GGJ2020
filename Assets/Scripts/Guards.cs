using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guards : MonoBehaviour
{
    private bool playerIsHiding = false;


    void Start()
    {
        CheckInteraction.onPlayerHiding += HiddenPlayer;
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerIsHiding)
        {
            //Debug.LogError("Peguei Voce!");
        }
    }

    private void HiddenPlayer()
    {
        if (playerIsHiding)
        {
            playerIsHiding = false;
        }
        else
        {
            playerIsHiding = true;
        }
    }
}
