using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private bool destroy = false;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private Rigidbody rb;
    private bool isExploded = false;
    

    public void Push(float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        Debug.Log("explode box");
        if (destroy)
        {
            if (isExploded)
            {
                return;
            }
            isExploded = true;

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }
}
