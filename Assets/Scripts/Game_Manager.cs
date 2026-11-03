using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;
    public string marcador;
    public AudioClip pointsScoredSound;
    public Audioclip Win_Sound;
    public AudioSource.Win_Sound
    public TMP_Text marcador;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(puntosJugador1 + "|" + puntosJugador2);
    }

    // Update is called once per frame
    void Update()
    {
        textomarcador.text = marcador;
        marcador.text = puntosJugador1 + "|" + puntosJugador2;
        if (puntosJugador1 == 5 || puntosJugador2 == 5)
        {
            AudioSource.Win_Sound.Play();
            SceneManager.LoadScene(0);
        }

    }
    public void UpdatePointsText()
    {
        marcador = puntosJugador1 + "/" + puntosJugador2;
        textomarcador.text = marcador;
        if (puntosJugador1 >= 5); 
    }
}


