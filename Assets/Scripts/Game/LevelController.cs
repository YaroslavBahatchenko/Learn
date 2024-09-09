using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    private int levelIndex;
    private int levelToDisplay;

    private void Awake()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        levelIndex = PlayerPrefs.GetInt("Level");
        if (levelIndex >= levels.Count)
        {
            levelIndex = 0;
            PlayerPrefs.SetInt("Level", levelIndex);
        }
        levelToDisplay = PlayerPrefs.GetInt("LevelToDisplay");
        Instantiate(levels[levelIndex], spawnPosition, Quaternion.identity);
    }

    public void IncreaseLevelIndex()
    {
        levelIndex++;
        PlayerPrefs.SetInt("Level", levelIndex);
        levelToDisplay++;
        PlayerPrefs.SetInt("LevelToDisplay", levelToDisplay);
    }

    public int GetLevelToDisplay()
    {
        return levelToDisplay + 1;
    }
}