using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform aimLine;
    [SerializeField] private Transform grenadeSpawnPoint;

    public Transform GetGrenadeSpawnPoint()
    {
        return grenadeSpawnPoint;
    }

    public Transform GetAimLine()
    {
        return aimLine;
    }
}

