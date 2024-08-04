using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        Ragdoll(false);
    }

    public void Ragdoll(bool enable)
    {
        foreach (Rigidbody body in ragdollBodies)
        {
            body.isKinematic = !enable;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = enable;
        }
    }
}
