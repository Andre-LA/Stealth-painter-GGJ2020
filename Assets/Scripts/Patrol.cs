using UnityEngine;
﻿using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private int numberOfNodes;
    private int currentNode;
    public GameObject lanterna;

    private bool playerIsHiding = false;
    private Animator Anim;
    public float direcao = 1f;
    public float axisX, axisY;

    public Transform[] moveSpots;
    void Start()
    {
        waitTime = startWaitTime;
        currentNode = moveSpots.Length-1;
        numberOfNodes = moveSpots.Length;
        CheckInteraction.onPlayerHiding += HiddenPlayer;
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[NextNode(currentNode)].position, speed * Time.deltaTime);
        axisX = Mathf.Clamp(transform.position.x - moveSpots[NextNode(currentNode)].position.x, -1f, 1f);
        axisY = Mathf.Clamp(transform.position.y - moveSpots[NextNode(currentNode)].position.y, -1f, 1f);
        verificaDirecao();
        verificaAnimacao();

        if (Vector2.Distance(transform.position, moveSpots[NextNode(currentNode)].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                currentNode = NextNode(currentNode);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    private int NextNode(int current)
    {
        int returning = current + 1;
        if(returning == numberOfNodes)
        {
            returning = 0;
        }
        return returning;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerIsHiding)
        {
            SceneManager.LoadScene(12);
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
        if (axisX > 0) { direcao = 1f; }                // valor do eixo positivo está indo para direita
        else if (axisX < 0) { direcao = -1f; }          // valor do eixo negativo está indo para esquerda
        transform.localScale = new Vector3(direcao, 1f, 1f);
    }

    public void verificaAnimacao()
    {
        int antes = Anim.GetInteger("situacao");

        if (axisY < -0.20f)
        {
            Anim.SetInteger("situacao", 1);
            lanterna.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
            return;
        }
        else
        {
            if (axisY > 0.20f)
            {
                Anim.SetInteger("situacao", 2);
                lanterna.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                return;
            }
        }

        if (axisX > 0.20f || axisX < -0.20f)
        {
            if (axisX < -0.20f)
            {
                lanterna.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
            }
            else
            {
                lanterna.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            }
            Anim.SetInteger("situacao", 3);
            return;
        }
    }
}
