using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene(EstadoDeJogo.faseAtualBI);
    }
    
    public void Sair()
    {
        const int CENA_MENU_INICIAL = 0;
        SceneManager.LoadScene(CENA_MENU_INICIAL);        
    }
}
