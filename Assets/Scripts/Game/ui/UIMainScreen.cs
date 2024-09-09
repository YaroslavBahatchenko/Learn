using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private int bombCount = 1;
    [SerializeField] private UIBombIcon bombIconPrefab;
    [SerializeField] private Transform bombGroup;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private UIController uIController;
    [SerializeField] private LevelController levelController;
    private List<UIBombIcon> bombIcons = new List<UIBombIcon>();

    private void Start()
    {
        for (int i = 0; i < bombCount; i++)
        {
            bombIcons.Add(Instantiate(bombIconPrefab, bombGroup));
        }

        levelNumber.text = "Level" + levelController.GetLevelToDisplay().ToString();
    }

    public void UseGrenade()
    {
        bombIcons.Last().UseGrenade();
        bombIcons.RemoveAt(bombIcons.Count - 1);
        if (bombIcons.Count == 0)
        {
            StartCoroutine(CheckPlayerLose());
        }
    }

    private IEnumerator CheckPlayerLose()
    {
        playerController.CannotShoot();
        yield return new WaitForSeconds(3f);
        if (enemyController.EnemyCount() > 0)
        {
            uIController.PlayerLose();
        }
    }

    public void SkipLevel()
    {
        levelController.IncreaseLevelIndex();
        SceneManager.LoadScene(0);
    }
}
