using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteraction : MonoBehaviour
{
    public GameObject alert;
    public delegate void Interactive();
    public static event Interactive onMonalisaStart, onMonalisaExit, onMonalisaReEnter;

    private bool monalisaLoaded = false;
    private bool nearInteractive = false;
    void Update()
    {
        if(!monalisaLoaded && nearInteractive && Input.GetButtonDown("Jump"))
        {
            onMonalisaStart?.Invoke();
            monalisaLoaded = true;
        }
        else if(monalisaLoaded && nearInteractive && Input.GetButtonDown("Jump"))
        {
            onMonalisaReEnter?.Invoke();
        }
        if(monalisaLoaded && Input.GetKeyDown(KeyCode.Escape))
        {
            onMonalisaExit?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            EstadoDeJogo.quadroAbertoID = collision.gameObject.GetComponent<Quadro>().id;
            alert.gameObject.SetActive(true);
            nearInteractive = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            alert.gameObject.SetActive(false);
            nearInteractive = false;
        }

    }
}
