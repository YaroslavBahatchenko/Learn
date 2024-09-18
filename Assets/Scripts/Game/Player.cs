using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform aimLine;
    [SerializeField] private Transform grenadeSpawnPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject grenade;

    private void Start()
    {
        grenade.SetActive(false);
    }
    public Transform GetGrenadeSpawnPoint()
    {
        return grenadeSpawnPoint;
    }

    public Transform GetAimLine()
    {
        return aimLine;
    }
    // персонаж начал прицеливаться
    public void StartAim()
    {
        animator.SetTrigger("Aim"); // запускаем анимацию прицеливания
        grenade.SetActive(true); // включаем отображение гранаты
    }

    // персонаж закончил прицеливаться
    public void ThrowGrenade()
    {
        animator.SetTrigger("Throw"); // запускаем анимацию броска
        grenade.SetActive(false); // выключаем отображение гранаты
    }
}

