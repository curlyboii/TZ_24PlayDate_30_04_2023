using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // access the GameManager from anywhere
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
