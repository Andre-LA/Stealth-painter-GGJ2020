using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreControl : MonoBehaviour
{
    public Text loreText;
    void Start()
    {
        UpdateLore();
    }


    private void UpdateLore()
    {
        if(EstadoDeJogo.faseAtual == 1)
        {
            loreText.text = "" +
            "\"The museum was attacked yesterday...\n" +
            "Importante paintings got vandalized...\n" +
            "Since I'm a restorer, I just can't leave\n" +
            "things like this. I gotta repair them!\"\n" +
            "\n" +
            "Restorer's diary\n" +
            "January 31, 2020.";
        }
    }
}
