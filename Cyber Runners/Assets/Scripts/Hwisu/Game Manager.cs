using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {
    Intro,
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Player player;
    public ScoreManager scoreManager;
    public ObstacleSpawn obstacleSpawn;
    public BackgroundScroll backgroundScroll;
    public BackgroundScroll groundScroll;
    public static GameManager Instance;
    public GameState State = GameState.Intro;
    public GameObject gameoverCanvas;

    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    public void ToShop()
    {
        SceneManager.LoadScene("Shop_Hwisu");
    }

    public void ToHome() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        State = GameState.Dead;
        backgroundScroll.scrollSpeed = 0;
        groundScroll.scrollSpeed = 0;
        scoreManager.gameObject.SetActive(false);
        obstacleSpawn.gameObject.SetActive(false);
        gameoverCanvas.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        gameoverCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
