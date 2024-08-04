using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBombIcon : MonoBehaviour
{
    [SerializeField] private Image bombIcon;
    [SerializeField] private Color inactiveBomb = Color.grey;
    [SerializeField] private GameObject cross;

    public void UseGrenade()
    {
        bombIcon.color = inactiveBomb;
        cross.SetActive(true);
    }
}
