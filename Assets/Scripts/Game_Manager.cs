using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;
    public TMP_Text marcador;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(puntosJugador1 + "|" + puntosJugador2);
    }

    // Update is called once per frame
    void Update()
    {
        marcador.text = puntosJugador1 + "|" + puntosJugador2;


    }
}
