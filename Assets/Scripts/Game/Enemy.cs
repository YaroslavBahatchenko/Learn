using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private RagdollController ragdollController;
    [SerializeField] private List<AudioClip> deathSouds = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;
    private EnemyController enemyController;
    private bool isDead = false;

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
        if (isDead)
        {
            return;
        }
        isDead = true;

        Debug.Log("Enemy dead");


        audioSource.clip = deathSouds[Random.Range(0, deathSouds.Count)];
        audioSource.Play();
        animator.enabled = false; // выключаем аниматор, чтобы заработал регдоллл
        ragdollController.Ragdoll(true); //включаем регдолл
        gameObject.layer = 7; // меняем слой у противика, чтобы с ним не пересекалась граната при следующем броске
        enemyController.RemoveEnemy(this); // удаляем убитого противника из общего списка
    }
}

