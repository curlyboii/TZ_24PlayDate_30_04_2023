using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // access the GameManager from anywhere
    public GameObject gameOverPanel; // game over
    public GameObject tapToMovePanel; // tap to move panel
    public bool gameStarted; // game is Start?



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0)) // first touch
            {
                GameStart();
            }
        }
    }

    void GameStart()
    {
        gameStarted = true;
        tapToMovePanel.SetActive(false);

    }


    public void GameOver()
    {
        Invoke("DelayRestart", 1f);
    }

    void DelayRestart()
    {

        gameOverPanel.SetActive(true);

    }

   public void RestartButton()
    {

        SceneManager.LoadScene(0);

    }    
}
