using TMPro;
using UnityEngine;
using UnityEngine.UI;

// made with the help of github copilot
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the Text UI element
    public Enemy enemySpawner;
    private int score = 0; // Initial score

    public void UpdateScore(int amount)
    {
        score += amount; // Update the score
        scoreText.text = "Ghosts killed: " + score; // Update the UI
    }

    public void LoseGame()
    {
  
        scoreText.text = "You Lost" ; // Update the UI
        enemySpawner.spawnInterval = 200;

    }
}
