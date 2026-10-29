using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void ExitGame()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Application.Quit();
    }
}
