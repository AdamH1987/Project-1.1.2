using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    GameObject Pausetext;
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown("Esc"))
        {
            gameIsPaused = !gameIsPaused;
            Pausetext.gameObject.SetActive(false);
            PauseGame();

        }
    }
    void PauseGame()
    {

        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            Pausetext.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Pausetext.gameObject.SetActive(false);
        }
    }
}
