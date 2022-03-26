using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Scenes nextScene; //On peut essayer de s�rialiser, le but c'est de choisir vers quelle sc�ne envoie la porte
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Manchou" || collision.gameObject.tag == "Pipoulpe")
        {
            SceneManager.LoadScene(nextScene.ToString());
        }
    }
}
