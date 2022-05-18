using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool onePlayerPresent = false;
    public Scenes nextScene; //On peut essayer de sérialiser, le but c'est de choisir vers quelle scène envoie la porte
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onePlayerPresent == true)
        {
            SceneManager.LoadScene(nextScene.ToString());
        }
        else
        {
            onePlayerPresent = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onePlayerPresent = false;
    }
}
