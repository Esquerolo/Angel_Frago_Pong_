using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;
    public string marcador;
    public AudioClip pointsScoredSound;
    public AudioClip WinSound;
    public AudioSource _AudioSource;
    public TMP_Text textomarcador;
    public GameObject winPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(puntosJugador1 + "|" + puntosJugador2);
    }

    // Update is called once per frame
    void Update()
    {
        textomarcador.text = marcador;
        textomarcador.text = puntosJugador1 + "|" + puntosJugador2;
        if (puntosJugador1 == 5 || puntosJugador2 == 5)
        {
            SceneManager.LoadScene(0);
        }

    }
    public void UpdatePointsText()
    {
        marcador = puntosJugador1 + "/" + puntosJugador2;
        textomarcador.text = marcador;
        if (puntosJugador1 >= 5 || puntosJugador2 >= 5)
        {
            _AudioSource.clip = WinSound;
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _AudioSource.clip = pointsScoredSound;
        }
        _AudioSource.Play();
       
    }
}


