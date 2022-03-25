using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("(Basile)-LvL1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
