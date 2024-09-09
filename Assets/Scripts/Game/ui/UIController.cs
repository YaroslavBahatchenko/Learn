using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIMainScreen mainScreen;
    [SerializeField] private UILoseScreen loseScreen;
    [SerializeField] private UIWinScreen winScreen;
    [SerializeField] private LevelController levelController;

    private void Start()
    {
        mainScreen.gameObject.SetActive(true);
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    public void PlayerWin()
    {
        mainScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        levelController.IncreaseLevelIndex();
    }

    public void PlayerLose()
    {
        mainScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
    }
}

