using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIWinScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text scoreToAdd;
    [SerializeField] private EnemyController enemyController;
    private int currentScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("Score");
        score.text = currentScore.ToString(); ;
        scoreToAdd.text = "+" + enemyController.GetLevelEnemyCount();
    }

    public void AddScore()
    {
        currentScore += enemyController.GetLevelEnemyCount();
        score.text = currentScore.ToString();
        scoreToAdd.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Score", currentScore);
    }
    public void ButtonContinue()
    {
        SceneManager.LoadScene(0);
    }
}
