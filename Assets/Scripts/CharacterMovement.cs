using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 8f;
    private bool canPlayerMove = true;

    public float direcao = 0.5f;
    public float axisX, axisY;

    public GameObject player;
    private Animator Anim;

    void Start()
    {
        CheckInteraction.onMonalisaStart += StopPlayerMovement;
        CheckInteraction.onMonalisaExit += StartPlayerMovement;
        CheckInteraction.onMonalisaReEnter += StopPlayerMovement;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        verificaDirecao();
        verificaAnimacao();

        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");
        if (axisX != 0 || axisY != 0)
        {
            MoveCharacter(player, new Vector2(axisX, axisY));
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

    public void MoveCharacter(GameObject character, Vector2 direction)
    {
        if (character.CompareTag("Player") && canPlayerMove)
        {
            character.transform.Translate(direction * playerSpeed * Time.deltaTime);
        }
        
    }

    private void StopPlayerMovement()
    {
        canPlayerMove = false;
    }

    private void StartPlayerMovement()
    {
        canPlayerMove = true;
    }

    private void UpdatePlayerAnim(float X, float Y)
    {
        
    }
}
