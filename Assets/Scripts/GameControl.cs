using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreTextPlayer1;
    public Text scoreTextPlayer2;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int birdsDead = 0;

    // Start is called before the first frame update
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (gameOver == true && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored(int playerNumber) {
        if (gameOver) {
            return;
        }

        if (playerNumber == 1) {
            scorePlayer1++;
            scoreTextPlayer1.text = "Player 1: " + scorePlayer1.ToString();
        } 
        
        if (playerNumber == 2) {
            scorePlayer2++;
            scoreTextPlayer2.text = "Player 2: " + scorePlayer2.ToString();
        }
    }

    public void BirdDied() {
        birdsDead++;

        if (birdsDead >= 2) {
            gameOverText.SetActive(true);
            gameOver = true;
        }
    }
}
