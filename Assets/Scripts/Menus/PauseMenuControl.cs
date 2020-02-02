using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour
{
    public Text mainText;
    public Button continueButton;
    public Button exitButton;
    public Button restartButton;

    private void Start()
    {
        restartButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
    }

    void Update()
    {
        if (EstadoDeJogo.gameIsOver)
        {
            restartButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
            mainText.text = "You got caught";
        }
    }
}
