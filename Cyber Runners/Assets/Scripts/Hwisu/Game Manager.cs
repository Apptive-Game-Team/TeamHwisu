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
        State = GameState.Dead;
        Debug.Log("게임 종료 처리를 진행합니다.");
    }
}
