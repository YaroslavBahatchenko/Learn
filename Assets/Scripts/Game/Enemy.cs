using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private RagdollController ragdollController;
    private EnemyController enemyController;

    private void Start()
    {
        // ищем контроллер на сцене
        enemyController = FindObjectOfType<EnemyController>();

        // противник регистрирует себя в контроллере
        enemyController.Register(this);
    }

    // смерть противника
    public void Death()
    {
        Debug.Log("Enemy dead");

        animator.enabled = false; // выключаем аниматор, чтобы заработал регдоллл
        ragdollController.Ragdoll(true); //включаем регдолл
        gameObject.layer = 7; // меняем слой у противика, чтобы с ним не пересекалась граната при следующем броске
        enemyController.RemoveEnemy(this); // удаляем убитого противника из общего списка
    }
}

