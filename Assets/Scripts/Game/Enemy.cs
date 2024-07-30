using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    private void Start()
    {
        ragdollBodies = animator.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in ragdollBodies)
        {
            body.isKinematic = true;
        }

        ragdollColliders = animator.GetComponentsInChildren<Collider>();
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
    }

    public void Death()
    {
        Debug.Log("Enemy dead");
        foreach (Rigidbody body in ragdollBodies)
        {
            body.isKinematic = false;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        gameObject.layer = 7;
    }
}
