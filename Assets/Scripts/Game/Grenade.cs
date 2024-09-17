using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float launchPower = 5f;
    [SerializeField] private int bounceCount = 3;
    [SerializeField] private float radius = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private float explosionForce = 10f;
    private int currentBounceCount = 0;

    public void Launch(Vector3 direction)
    {
        Debug.Log("Launch grenade");
        // бросаем гранату в указанном напраплении
        rb.AddForce(direction * launchPower, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6 || other.gameObject.layer == 9) {
            Explode();        
        }
        currentBounceCount++;
        if (currentBounceCount >= bounceCount)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Explode");
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