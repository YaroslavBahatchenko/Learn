using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private RagdollController ragdollController;

    private void Start()
    {
        EnemyController.Instance.AddEnemy(this);
    }

    public void Death()
    {
        Debug.Log("Enemy dead");
        animator.enabled = false;
        ragdollController.Ragdoll(true);
        gameObject.layer = 7;
        EnemyController.Instance.RemoveEnemy(this);
    }
}
