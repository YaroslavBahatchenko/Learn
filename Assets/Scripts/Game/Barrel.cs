using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private float explosionForce = 10f;
    private bool isExploded = false;

    public void Explode()
    {
        if (isExploded)
        {
            return;
        }
        isExploded = true;

        Debug.Log("Explode Barrel");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, mask);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Death();
            }

            if (hitCollider.TryGetComponent<Box>(out Box box))
            {
                box.Push(explosionForce, transform.position, radius);
            }

            if (hitCollider.TryGetComponent<Barrel>(out Barrel barrel))
            {
                barrel.Explode();
            }

        }
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
