using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("Clément_Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
