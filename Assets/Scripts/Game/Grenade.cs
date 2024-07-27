using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float launchPower = 5f;
    [SerializeField] private int bounceCount = 3;
    [SerializeField] private ParticleSystem explosionEffect;
    private int curentBounceCount = 0;

    public void Launch(Vector3 direction)
    {
        Debug.Log("Launch grenade");
        rb.AddForce(direction * launchPower, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        curentBounceCount++;
        if (curentBounceCount >= bounceCount)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Explode");
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
