using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : SingletonMono<UIController>
{
    [SerializeField] private int bombCount = 1;
    [SerializeField] private UIBombIcon bombIconPrefab;
    [SerializeField] private Transform bombGroup;
    private List<UIBombIcon> bombIcons = new List<UIBombIcon>();

    private void Start()
    {
        for (int i = 0; i < bombCount; i++)
        {
            bombIcons.Add(Instantiate(bombIconPrefab, bombGroup));
        }
    }

    public void UseGrenade()
    {
        bombIcons.Last().UseGrenade();
        bombIcons.RemoveAt(bombIcons.Count - 1);
        if (bombIcons.Count == 0)
        {
            PlayerController.Instance.CannotShoot();
        }
    }
}
