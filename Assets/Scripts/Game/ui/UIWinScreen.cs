using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIWinScreen : MonoBehaviour
{
    public void ButtonContinue()
    {
        SceneManager.LoadScene(0);
    }
}
