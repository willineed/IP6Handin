using TMPro;
using UnityEngine;

// made with the help of github copilot
public class Enemy2 : MonoBehaviour
{

    public int scoreValue = 1; // Points this prefab is worth
    UIManager uiManager;
    private void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();

    }

    // if bullet collides with enemy, destroy both
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (uiManager != null)
            {
                uiManager.UpdateScore(scoreValue);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
         
            
        }

        if (collision.gameObject.tag == "Player")
        {
            
            if (uiManager != null)
            {
                uiManager.LoseGame();
            }
            
            Destroy(gameObject);

        }
    }
}
