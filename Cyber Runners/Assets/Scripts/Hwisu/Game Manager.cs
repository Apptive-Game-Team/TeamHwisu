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
    public HealthManager healthManager;
    public ScoreManager scoreManager;
    public BackgroundScroll backgroundScroll;
    public BackgroundScroll groundScroll;
    public static GameManager Instance;
    public GameState State = GameState.Intro;

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

    public void GameOver()
    {
        Debug.Log("게임 종료 처리를 진행합니다.");
        State = GameState.Dead;
        player.GameOver();
        backgroundScroll.scrollSpeed = 0;
        groundScroll.scrollSpeed = 0;
        healthManager.enabled = false;
        scoreManager.enabled = false;
    }
}
