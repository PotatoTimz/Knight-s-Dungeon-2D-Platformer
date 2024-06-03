using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject gameWinUI; // Assign in the editor

    private void Start()
    {
        gameWinUI.SetActive(false); // Ensure the UI is hidden at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Assuming the player has a tag named "Player"
        if (collision.CompareTag("Player"))
        {
            Player playerStats = collision.gameObject.GetComponent<Player>();
            playerStats.numOfClears += 1;
            playerStats.saveManager.SaveToJson();

            CollectStar();
        }
    }

    private void CollectStar()
    {
        gameObject.SetActive(false); // Optionally hide or deactivate the star
        gameWinUI.SetActive(true); // Show the GameWin UI
        Time.timeScale = 0f; // Pause the game
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
