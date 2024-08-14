using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoseScreen : MonoBehaviour
{
    public void ButtonRestart()
    {
        SceneManager.LoadScene(0);
    }
}
