using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    public void Start()
    {
        Debug.Log("start");
    }

    private void Awake()
    {
        Debug.Log("aweke");
    }

    private void OnEnable()
    {
        Debug.Log("on enable");
    }
}
