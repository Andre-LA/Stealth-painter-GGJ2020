using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guards : MonoBehaviour
{
    private bool playerIsHiding = false;
    private Animator Anim;
    public float direcao = 0.5f;
    public float axisX, axisY;


    void Start()
    {
        CheckInteraction.onPlayerHiding += HiddenPlayer;
        Anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        verificaDirecao();
        verificaAnimacao();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerIsHiding)
        {
            Debug.LogError("Peguei Voce!");
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

    public void verificaDirecao()
    {
        if (axisX > 0) { direcao = 0.5f; }                // valor do eixo positivo está indo para direita
        else if (axisX < 0) { direcao = -0.5f; }          // valor do eixo negativo está indo para esquerda
        transform.localScale = new Vector3(direcao, 0.5f, 0.5f);
    }

    public void verificaAnimacao()
    {
        int antes = Anim.GetInteger("situacao");

        if (axisY < -0.05f)
        {
            Anim.SetInteger("situacao", 1);
            return;
        }
        else
        {
            if (axisY > 0.05f)
            {
                Anim.SetInteger("situacao", 2);
                return;
            }
        }

        if (axisX > 0.05f || axisX < -0.05f)
        {
            Anim.SetInteger("situacao", 3);
            return;

        }

        if (antes == 3)
            Anim.SetInteger("situacao", 4);
        else
            Anim.SetInteger("situacao", 0);
    }
}
