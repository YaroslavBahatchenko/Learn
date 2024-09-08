using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    private int levelIndex = 0;

    private void Awake()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        Instantiate(levels[levelIndex], spawnPosition, Quaternion.identity);
    }

    public void IncreaseLevelIndex()
    {
        levelIndex += 1;
    }
}
