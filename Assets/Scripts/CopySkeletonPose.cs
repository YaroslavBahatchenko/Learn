using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySkeletonPose : MonoBehaviour
{
    [SerializeField] Transform from;
    [SerializeField] Transform to;
    
    [ContextMenu("Copy Skeleton Pose")]
    void CopyPose()
    {
        Transform[] fromChildren = from.GetComponentsInChildren<Transform>();
        Transform[] toChildren = to.GetComponentsInChildren<Transform>();

        for (int i = 0; i < fromChildren.Length; i++)
        {
            toChildren[i].localPosition = fromChildren[i].localPosition;
            toChildren[i].localEulerAngles = fromChildren[i].localEulerAngles;
            toChildren[i].localScale = fromChildren[i].localScale;
        }

        Debug.Log("Done");
    }
}
