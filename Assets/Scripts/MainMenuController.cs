using UnityEngine;
using UnityEngine.SceneManagement; // Make sure you have this line to use SceneManager
using TMPro;


public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuUI; // Assign this in the inspector
    public Player playerStats;
    public TMP_Text displayClears;
    public TMP_Text displayDeaths;

    private void Start()
    {
        // Ensure the game starts in a paused state
        Time.timeScale = 0f;
        displayClears.text = "Number of Clears: " + playerStats.numOfClears;
        displayDeaths.text = "Number of Deaths: " + playerStats.numOfDeaths;
    }

    // This method is called when the "Play Game" button is clicked
    public void PlayGame()
    {
        // Hide the main menu UI
        mainMenuUI.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }
}
