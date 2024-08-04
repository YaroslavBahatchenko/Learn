using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRagdoll : MonoBehaviour
{
    [ContextMenu("Remove Ragdoll components")]
    void Remove()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        Debug.Log("colliders count = " + colliders.Length);
        foreach (var item in colliders)
        {
            DestroyImmediate(item);
        }

        Joint[] joints = GetComponentsInChildren<Joint>();
        foreach (var item in joints)
        {
            DestroyImmediate(item);
        }

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var item in rigidbodies)
        {
            DestroyImmediate(item);
        }
    }
}
