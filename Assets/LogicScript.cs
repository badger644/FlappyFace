using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text highScore;
    public Text scoreText;
    public GameObject GameOverScreen;
    public GameObject MainMenu;
    public GameObject PipeSpawner;
    public AudioSource Ding;
    public AudioSource Explosion;
    public bool alreadyPlayed;
    


    void Start()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        alreadyPlayed = false;
}

    
        
    

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = "Highscore: " + playerScore.ToString();
        }
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        
        GameOverScreen.SetActive(true);
        

    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            MainMenu.SetActive(false);
            PipeSpawner.SetActive(true);
            GameOverScreen.SetActive(false);
        }


    }

}
