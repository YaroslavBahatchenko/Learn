using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoseScreen : MonoBehaviour
{
    [SerializeField] private LevelController levelController;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void SkipLevel()
    {
        levelController.IncreaseLevelIndex();
        Restart();
    }
}