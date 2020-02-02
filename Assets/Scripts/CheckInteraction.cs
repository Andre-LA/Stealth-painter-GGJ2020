using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    public GameObject alert;
    public delegate void Interactive();
    public static event Interactive onMonalisaStart, onMonalisaExit, onMonalisaReEnter, onPlayerHiding;

    static bool monalisaLoaded = false;
    private bool nearInteractive = false;
    private bool nearPainting = false;
    private bool nearDoor = false;
    
    void Update()
    {
        ActionCheck();
        PaintingLogic();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Painting"))
        {
            Alert();
            nearPainting = true;            
        }
        if (collision.CompareTag("Interactive"))
        {
            Alert();
            nearInteractive = true;
        }
        if (collision.CompareTag("Door"))
        {
            Alert();
            nearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Painting"))
        {
            Alert();
            nearPainting = false;
        }
        if (collision.CompareTag("Interactive"))
        {
            Alert();
            nearInteractive = false;
        }
        if (collision.CompareTag("Door"))
        {
            Alert();
            nearDoor = false;
        }
    }

    private void Alert()
    {
        if (alert.gameObject.activeSelf == false)
        {
            alert.gameObject.SetActive(true);
        }
        else
        {
            alert.gameObject.SetActive(false);
        }
    }

    private void PaintingLogic()
    {
        if (!monalisaLoaded && nearPainting && Input.GetButtonDown("Jump"))
        {
            onMonalisaStart?.Invoke();
            monalisaLoaded = true;
        }
        else if (monalisaLoaded && nearPainting && Input.GetButtonDown("Jump") && !EstadoDeJogo.quadroAberto)
        {
            onMonalisaReEnter?.Invoke();
        }
        else if (monalisaLoaded && Input.GetButtonDown("Jump"))
        {
            onMonalisaExit?.Invoke();
        }
    }

    private void ActionCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (nearDoor)
            {
                if (EstadoDeJogo.podeProsseguirFase)
                {
                    FindObjectOfType<Porta>().ProsseguirFase();
                }
            }

            if (nearInteractive && Input.GetButtonDown("Jump"))
            {
                onPlayerHiding?.Invoke();
            }
        }
    }
}

