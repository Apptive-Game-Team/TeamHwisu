using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Health References")]
    public int score = 0;
    public Text scoreText;
    public float scoreInterval = 1f;
    public int scoreIncrement;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
    }

    public void GameStart() {
        StartCoroutine(AddScoreRoutine());
    }

    IEnumerator AddScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreInterval);
            score += scoreIncrement;
            UpdateScoreUI();
        }
    }
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
