using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player playerStats;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        // Resume time in case the game was paused
        Time.timeScale = 1;

        playerStats.numOfDeaths += 1;
        playerStats.coinManager.coinCount = 0;
        playerStats.saveManager.SaveToJson();

        // Get the current scene name and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
