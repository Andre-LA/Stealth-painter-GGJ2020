using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    public GameObject alert;
    public delegate void Interactive();
    public static event Interactive onMonalisaStart, onMonalisaExit, onMonalisaReEnter;

    private bool monalisaLoaded = false;
    private bool nearInteractive = false;
    private bool nearPainting = false;
    private bool nearDoor = false;
    private bool paintingOnScreen = false;
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
            paintingOnScreen = true;
        }
        else if (!paintingOnScreen && monalisaLoaded && nearPainting && Input.GetButtonDown("Jump"))
        {
            onMonalisaReEnter?.Invoke();
            paintingOnScreen = true;
        }
        else if (paintingOnScreen && monalisaLoaded && Input.GetButtonDown("Jump"))
        {
            onMonalisaExit?.Invoke();
            paintingOnScreen = false;
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
                    Debug.Log("Proxima fase!");
                }
                else
                {
                    Debug.Log("Ainda não pode ir!");
                }
            }

            if (nearInteractive)
            {
                Debug.Log("Fazer algo!");
            }
        }
    }
}

