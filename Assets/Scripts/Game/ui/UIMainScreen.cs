using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIMainScreen : MonoBehaviour
{
    [SerializeField] private int bombCount = 1;
    [SerializeField] private UIBombIcon bombIconPrefab;
    [SerializeField] private Transform bombGroup;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private UIController uIController;
    private List<UIBombIcon> bombIcons = new List<UIBombIcon>();

    private void Start()
    {
        for (int i = 0; i < bombCount; i++)
        {
            bombIcons.Add(Instantiate(bombIconPrefab, bombGroup));
        }
    }

    public void UseGrenade()
    {
        bombIcons.Last().UseGrenade();
        bombIcons.RemoveAt(bombIcons.Count - 1);
        if (bombIcons.Count == 0)
        {
            playerController.CannotShoot();
            if (enemyController.EnemyCount() > 0)
            {
                uIController.PlayerLose();
            }
        }
    }
}
