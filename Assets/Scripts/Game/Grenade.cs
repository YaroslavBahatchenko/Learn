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
    private int currentBounceCount = 0;

    public void Launch(Vector3 direction)
    {
        Debug.Log("Launch grenade");
        // бросаем гранату в указанном напраплении
        rb.AddForce(direction * launchPower, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
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
            hitCollider.GetComponent<Enemy>().Death();
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